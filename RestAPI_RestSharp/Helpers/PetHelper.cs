using RestAPI_RestSharp.DataModels;
using RestAPI_RestSharp.Resources;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace RestAPI_RestSharp.Helpers
{
    public class PetHelper : Endpoints
    {
        public readonly List<PetModel> cleanUpList = new();

        public static Task<PetModel> CreatePetModel()
        {
            List<Tag> tags = new();
            tags.Add(new Tag()
            {
                Id = 123454323,
                Name = "Pet"
            });

            PetModel pet = new()
            {
                Id = 123454321,
                Category = new()
                {
                    Id = 123454322,
                    Name = "Dog"
                },
                Name = "Vixen",
                PhotoUrls = new List<string>() { "PhotoUrl_1" },
                Tags = tags,
                Status = "Available"
            };

            return Task.FromResult(pet);
        }

        public async Task<PetModel> GetPetByIdMethod(int petId)
        {
            PetModel petData = new();
            var restRequest = new RestRequest(GetURI($"{PetsEndPoint}/{petId}"), Method.Get);
            var restResponse = await restClient.ExecuteAsync<PetModel>(restRequest);
            petData = restResponse.Data;

            return petData;
        }

        public async Task<RestResponse> PostPetMethod(PetModel petData)
        {
            var temp = GetURI(PetsEndPoint);
            var postRestRequest = new RestRequest(GetURI(PetsEndPoint)).AddJsonBody(petData);
            var postRestResponse = await restClient.ExecutePostAsync(postRestRequest);

            return postRestResponse;
        }
    }
}
