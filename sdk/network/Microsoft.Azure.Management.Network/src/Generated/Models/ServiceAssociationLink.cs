// <auto-generated>
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.
//
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.
// </auto-generated>

namespace Microsoft.Azure.Management.Network.Models
{
    using Microsoft.Rest;
    using Microsoft.Rest.Serialization;
    using Newtonsoft.Json;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// ServiceAssociationLink resource.
    /// </summary>
    [Rest.Serialization.JsonTransformation]
    public partial class ServiceAssociationLink : SubResource
    {
        /// <summary>
        /// Initializes a new instance of the ServiceAssociationLink class.
        /// </summary>
        public ServiceAssociationLink()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the ServiceAssociationLink class.
        /// </summary>
        /// <param name="id">Resource ID.</param>
        /// <param name="linkedResourceType">Resource type of the linked
        /// resource.</param>
        /// <param name="link">Link to the external resource.</param>
        /// <param name="provisioningState">Provisioning state of the
        /// ServiceAssociationLink resource.</param>
        /// <param name="allowDelete">If true, the resource can be
        /// deleted.</param>
        /// <param name="locations">A list of locations.</param>
        /// <param name="name">Name of the resource that is unique within a
        /// resource group. This name can be used to access the
        /// resource.</param>
        /// <param name="etag">A unique read-only string that changes whenever
        /// the resource is updated.</param>
        /// <param name="type">Resource type.</param>
        public ServiceAssociationLink(string id = default(string), string linkedResourceType = default(string), string link = default(string), string provisioningState = default(string), bool? allowDelete = default(bool?), IList<string> locations = default(IList<string>), string name = default(string), string etag = default(string), string type = default(string))
            : base(id)
        {
            LinkedResourceType = linkedResourceType;
            Link = link;
            ProvisioningState = provisioningState;
            AllowDelete = allowDelete;
            Locations = locations;
            Name = name;
            Etag = etag;
            Type = type;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// Gets or sets resource type of the linked resource.
        /// </summary>
        [JsonProperty(PropertyName = "properties.linkedResourceType")]
        public string LinkedResourceType { get; set; }

        /// <summary>
        /// Gets or sets link to the external resource.
        /// </summary>
        [JsonProperty(PropertyName = "properties.link")]
        public string Link { get; set; }

        /// <summary>
        /// Gets provisioning state of the ServiceAssociationLink resource.
        /// </summary>
        [JsonProperty(PropertyName = "properties.provisioningState")]
        public string ProvisioningState { get; private set; }

        /// <summary>
        /// Gets or sets if true, the resource can be deleted.
        /// </summary>
        [JsonProperty(PropertyName = "properties.allowDelete")]
        public bool? AllowDelete { get; set; }

        /// <summary>
        /// Gets or sets a list of locations.
        /// </summary>
        [JsonProperty(PropertyName = "properties.locations")]
        public IList<string> Locations { get; set; }

        /// <summary>
        /// Gets or sets name of the resource that is unique within a resource
        /// group. This name can be used to access the resource.
        /// </summary>
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        /// <summary>
        /// Gets a unique read-only string that changes whenever the resource
        /// is updated.
        /// </summary>
        [JsonProperty(PropertyName = "etag")]
        public string Etag { get; private set; }

        /// <summary>
        /// Gets or sets resource type.
        /// </summary>
        [JsonProperty(PropertyName = "type")]
        public string Type { get; set; }

    }
}
