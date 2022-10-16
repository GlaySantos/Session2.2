using Microsoft.VisualStudio.TestTools.UnitTesting;
using RestAPI_RestSharp.DataModels;
using RestAPI_RestSharp.Helpers;
using RestAPI_RestSharp.Resources;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace RestAPI_RestSharp.Tests
{
    [TestClass]
    public class PetTests : PetHelper
    {

        [TestInitialize]
        public async Task TestInitialize()
        {
            restClient = new RestClient();
        }

        [TestCleanup]
        public async Task TestCleanup()
        {
            foreach (var data in cleanUpList)
            {
                var restRequest = new RestRequest(GetURI($"{PetsEndPoint}/{data.Id}"));
                await restClient.DeleteAsync(restRequest);
            }
        }

        [TestMethod]
        public async Task PostMethod()
        {
            #region arrange
            PetModel petData = await CreatePetModel();
            #endregion

            #region act
            var postRestResponse = await PostPetMethod(petData);
            cleanUpList.Add(petData);
            var restResponse = await GetPetByIdMethod(petData.Id);
            #endregion

            #region assert
            Assert.AreEqual(HttpStatusCode.OK, postRestResponse.StatusCode, "Status code is not equal to 200");
            Assert.AreEqual(petData.Id, restResponse.Id, "Id not matching");
            Assert.AreEqual(petData.Category.Id, restResponse.Category.Id, "Category Id not matching");
            Assert.AreEqual(petData.Category.Name, restResponse.Category.Name, "Category Name not matching");
            Assert.AreEqual(petData.Name, restResponse.Name, "Name not matching");
            Assert.AreEqual(petData.PhotoUrls[0], restResponse.PhotoUrls[0], "PhotoUrls not matching");
            Assert.AreEqual(petData.Tags[0].Id, restResponse.Tags[0].Id, "Tags Id not matching");
            Assert.AreEqual(petData.Tags[0].Name, restResponse.Tags[0].Name, "Tags Name not matching");
            Assert.AreEqual(petData.Status, restResponse.Status, "Status not matching");
            #endregion
        }
    }
}
