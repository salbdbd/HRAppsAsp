using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarTech.BLL.DBConfiguration;

    public class DapperContext
    {
        private readonly IConfiguration _configuration;

        public DapperContext(IConfiguration configuration) => _configuration = configuration;

        public IDbConnection GetDbConnection() => new SqlConnection(_configuration["DatabaseSettings:ConnectionString"]);


    }

