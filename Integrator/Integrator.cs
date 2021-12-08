using Domain.Models;
using Integrator.Interface;
using Microsoft.Extensions.Configuration;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Integrator
{
    public class Integrator : IIntegrator
    {
        private readonly string _url;
        public Integrator(IConfiguration configuration)
        {
            _url = configuration["API_WEBMOTORS"];
        }
        public async Task<IEnumerable<Brand>> GetBrand()
        {
            var client = new RestClient(_url);
            var request = new RestRequest("/OnlineChallenge/Make", Method.GET);
            var response = await client.ExecuteAsync<List<Brand>>(request);
            if (response.StatusCode != System.Net.HttpStatusCode.OK)
                throw new Exception(
                    string.Format(
                        "Error: {0} | {1} | {2}",
                        response.StatusCode,
                        response.ErrorMessage,
                        response.Content
                    ),
                    response.ErrorException
                );

            return response.Data;
        }

        public async Task<IEnumerable<Model>> GetModel(int brandId)
        {
            var client = new RestClient(_url);
            var request = new RestRequest("/OnlineChallenge/Model", Method.GET).AddQueryParameter("MakeID", brandId.ToString());
            var response = await client.ExecuteAsync<List<Model>>(request);
            if (response.StatusCode != System.Net.HttpStatusCode.OK)
                throw new Exception(
                    string.Format(
                        "Error: {0} | {1} | {2}",
                        response.StatusCode,
                        response.ErrorMessage,
                        response.Content
                    ),
                    response.ErrorException
                );

            return response.Data;
        }

        public async Task<IEnumerable<Domain.Models.Version>> GetVersion(int modelId)
        {
            var client = new RestClient(_url);
            var request = new RestRequest("/OnlineChallenge/Version", Method.GET).AddQueryParameter("ModelID", modelId.ToString());
            var response = await client.ExecuteAsync<List<Domain.Models.Version>>(request);
            if (response.StatusCode != System.Net.HttpStatusCode.OK)
                throw new Exception(
                    string.Format(
                        "Error: {0} | {1} | {2}",
                        response.StatusCode,
                        response.ErrorMessage,
                        response.Content
                    ),
                    response.ErrorException
                );

            return response.Data;
        }
    }
}
