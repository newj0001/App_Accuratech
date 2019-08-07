using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace App_Accurratech.Model
{
    public class MenuModel
    {
        public int Id { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }
        public string Description { get; set; }
    }
}
