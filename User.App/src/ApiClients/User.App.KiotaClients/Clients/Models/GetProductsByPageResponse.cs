// <auto-generated/>

#pragma warning disable CS0618
using Microsoft.Kiota.Abstractions.Extensions;
using Microsoft.Kiota.Abstractions.Serialization;
using System.Collections.Generic;
using System.IO;
using System;

namespace User.App.KiotaClients.Catalogs.Models
{
    [global::System.CodeDom.Compiler.GeneratedCode("Kiota", "1.0.0")]
#pragma warning disable CS1591
    public partial class GetProductsByPageResponse : IAdditionalDataHolder, IParsable
#pragma warning restore CS1591
    {
        /// <summary>Stores additional data not described in the OpenAPI description found when deserializing. Can be used for serialization as well.</summary>
        public IDictionary<string, object> AdditionalData { get; set; }

        /// <summary>The products property</summary>
        public global::User.App.KiotaClients.Catalogs.Models.IPageListOfProductDto Products { get; set; }

        /// <summary>
        /// Instantiates a new <see cref="global::User.App.KiotaClients.Catalogs.Models.GetProductsByPageResponse"/> and sets the default values.
        /// </summary>
        public GetProductsByPageResponse()
        {
            AdditionalData = new Dictionary<string, object>();
        }

        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// </summary>
        /// <returns>A <see cref="global::User.App.KiotaClients.Catalogs.Models.GetProductsByPageResponse"/></returns>
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        public static global::User.App.KiotaClients.Catalogs.Models.GetProductsByPageResponse
            CreateFromDiscriminatorValue(IParseNode parseNode)
        {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new global::User.App.KiotaClients.Catalogs.Models.GetProductsByPageResponse();
        }

        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        /// <returns>A IDictionary&lt;string, Action&lt;IParseNode&gt;&gt;</returns>
        public virtual IDictionary<string, Action<IParseNode>> GetFieldDeserializers()
        {
            return new Dictionary<string, Action<IParseNode>>
            {
                {
                    "products",
                    n =>
                    {
                        Products =
                            n.GetObjectValue<global::User.App.KiotaClients.Catalogs.Models.IPageListOfProductDto>(
                                global::User.App.KiotaClients.Catalogs.Models.IPageListOfProductDto
                                    .CreateFromDiscriminatorValue);
                    }
                },
            };
        }

        /// <summary>
        /// Serializes information the current object
        /// </summary>
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        public virtual void Serialize(ISerializationWriter writer)
        {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            writer.WriteObjectValue<global::User.App.KiotaClients.Catalogs.Models.IPageListOfProductDto>("products",
                Products);
            writer.WriteAdditionalData(AdditionalData);
        }
    }
}
#pragma warning restore CS0618