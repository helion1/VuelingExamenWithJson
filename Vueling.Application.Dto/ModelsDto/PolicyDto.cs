using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vueling.Application.Dto {
    public class PolicyDto {
        public PolicyDto() {
        }

        public PolicyDto(string id, decimal amountInsured, string email,
            DateTime inceptionDate, bool installmentPayment, string clientId) {

            Id = id;
            AmountInsured = amountInsured;
            Email = email;
            InceptionDate = inceptionDate;
            InstallmentPayment = installmentPayment;
            ClientId = clientId;
        }

        [JsonProperty("id")]
        public string Id { get; set; }
        [JsonProperty("amountInsured")]
        public decimal AmountInsured { get; set; }
        [JsonProperty("email")]
        public string Email { get; set; }
        [JsonProperty("inceptionDate")]
        public System.DateTime InceptionDate { get; set; }
        [JsonProperty("installmentPayment")]
        public bool InstallmentPayment { get; set; }
        [JsonProperty("clientId")]
        public string ClientId { get; set; }

    }
}
