﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Core.Http;
using Azure.Core.Pipeline;
using Azure.Core.Testing;
using NUnit.Framework;

namespace Azure.Core.Tests
{
    public class FixedRetryPolicyTests : RetryPolicyTestBase
    {
        public FixedRetryPolicyTests(bool isAsync) : base(RetryMode.Fixed, isAsync) { }

        [Test]
        public async Task WaitsBetweenRetries()
        {
            var responseClassifier = new MockResponseClassifier(retriableCodes: new[] { 500 });
            var policy = new RetryPolicyMock(RetryMode.Fixed, delay: TimeSpan.FromSeconds(3));
            var mockTransport = CreateMockTransport();
            var task = SendGetRequest(mockTransport, policy, responseClassifier);

            await mockTransport.RequestGate.Cycle(new MockResponse(500));

            var delay = await policy.DelayGate.Cycle();
            Assert.AreEqual(delay, TimeSpan.FromSeconds(3));

            await mockTransport.RequestGate.Cycle(new MockResponse(200));

            var response = await task.TimeoutAfterDefault();
            Assert.AreEqual(200, response.Status);
        }

        [Test]
        public async Task WaitsSameAmountEveryTime()
        {
            var responseClassifier = new MockResponseClassifier(retriableCodes: new[] { 500 });
            var policy = new RetryPolicyMock(RetryMode.Fixed, delay: TimeSpan.FromSeconds(3), maxRetries: 3);
            var mockTransport = CreateMockTransport();
            var task = SendGetRequest(mockTransport, policy, responseClassifier);

            await mockTransport.RequestGate.Cycle(new MockResponse(500));

            for (int i = 0; i < 3; i++)
            {
                var delay = await policy.DelayGate.Cycle();
                Assert.AreEqual(delay, TimeSpan.FromSeconds(3));

                await mockTransport.RequestGate.Cycle(new MockResponse(500));
            }

            var response = await task.TimeoutAfterDefault();
            Assert.AreEqual(500, response.Status);
        }

        [Theory]
        [TestCase(2, 3, 3)]
        [TestCase(3, 2, 3)]
        public async Task UsesLargerOfDelayAndServerDelay(int delay, int retryAfter, int expected)
        {
            var responseClassifier = new MockResponseClassifier(retriableCodes: new[] { 500 });
            var policy = new RetryPolicyMock(RetryMode.Fixed, delay: TimeSpan.FromSeconds(delay));
            var mockTransport = CreateMockTransport();
            var task = SendGetRequest(mockTransport, policy, responseClassifier);

            MockResponse mockResponse = new MockResponse(500);
            mockResponse.AddHeader(new HttpHeader("Retry-After", retryAfter.ToString()));

            await mockTransport.RequestGate.Cycle(mockResponse);

            var retryDelay = await policy.DelayGate.Cycle();

            await mockTransport.RequestGate.Cycle(new MockResponse(501));

            var response = await task.TimeoutAfterDefault();

            Assert.AreEqual(TimeSpan.FromSeconds(expected), retryDelay);
            Assert.AreEqual(501, response.Status);
        }
    }
}
