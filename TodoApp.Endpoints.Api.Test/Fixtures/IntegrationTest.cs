using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using TodoApp.Infra.Data.SqlServer;
using TodoApp.Infra.Data.SqlServer.Queries;
using Xunit;

namespace TodoApp.Endpoints.Api.Test.Fixtures
{
    public class IntegrationTest : IClassFixture<ApiFixture>
    {

        protected readonly ApiFixture _factory;
        protected readonly HttpClient _client;

        public IntegrationTest(ApiFixture fixture)
        {
            _factory = fixture;
            _client = _factory.CreateClient();

        }

       

    }
}
