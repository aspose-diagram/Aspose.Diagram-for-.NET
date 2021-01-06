using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Aspose.App.Diagram.Pages.Models.SEO
{
    public class LocalBusiness:SeoElement
    {		
		[JsonProperty("@type")]
		public override string Type { get; set; } = "LocalBusiness";

		[JsonProperty("name")]
		public string Name { get; set; } = "Aspose Pty Ltd";

		[JsonProperty("image")]
		public string Image { get; set; } //= "https://joomla-asposeapp.dynabic.com/templates/asposeapp/images/product-family/aspose-diagram-app.png";

		[JsonProperty("telephone")]
		public string Telephone { get; set; } = "+19033061676";

		[JsonProperty("aggregateRating")]
		public AggregateRating AggregateRating { get; set; } = new AggregateRating();

		[JsonProperty("address")]
		public Adress Adress { get; set; } = new Adress();

		[JsonProperty("priceRange")]
		public string PriceRange { get; set; } = "$$";

		[JsonProperty("url")]
		public string Url { get; set; } = "https://www.aspose.com/";
	}

    public class AggregateRating
    {
        [JsonProperty("@type")]
        public string Type { get; set; }

        [JsonProperty("worstRating")]
        public string WorstRating { get; internal set; }

        [JsonProperty("bestRating")]
        public string BestRating { get; internal set; }

        [JsonProperty("ratingValue")]
        public string RatingValue { get; internal set; }

        [JsonProperty("ratingCount")]
        public string RatingCount { get; internal set; }

        [JsonProperty("reviewCount")]
        public string ReviewCount { get; internal set; }

    }
}
