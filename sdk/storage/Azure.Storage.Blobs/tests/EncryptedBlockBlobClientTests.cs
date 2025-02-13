﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

using System;
using System.IO;
using System.Threading.Tasks;
using Azure.Core.Testing;
using Azure.Storage.Blobs.Specialized;
using Azure.Storage.Test.Shared;
using NUnit.Framework;

namespace Azure.Storage.Blobs.Test
{
    public class EncryptedBlockBlobClientTests : BlobTestBase
    {
        public EncryptedBlockBlobClientTests(bool async)
            : base(async, null /* RecordedTestMode.Record /* to re-record */)
        {
        }

        // Placeholder test to verify things work end-to-end
        [Test]
        public async Task DeleteAsync()
        {
            using (this.GetNewContainer(out var container))
            {
                // First upload a regular block blob
                var blobName = this.GetNewBlobName();
                var blob = this.InstrumentClient(container.GetBlockBlobClient(blobName));
                var data = this.GetRandomBuffer(Constants.KB);
                using var stream = new MemoryStream(data);
                await blob.UploadAsync(stream);

                // Create an EncryptedBlockBlobClient pointing at the same blob
                var encryptedBlob = this.InstrumentClient(container.GetEncryptedBlockBlobClient(blobName));

                // Delete the blob
                var response = await encryptedBlob.DeleteAsync();
                Assert.IsNotNull(response.Headers.RequestId);
            }
        }
    }
}
