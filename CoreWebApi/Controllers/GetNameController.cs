﻿using Amazon;
using Amazon.Runtime;
using Amazon.SQS;
using Amazon.SQS.Model;
using Azure.Core;
using CoreWebApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.SqlServer.Storage.Internal;
using System.Text.Json;
using static System.Net.WebRequestMethods;

namespace CoreWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GetNameController : ControllerBase
    {
        //private readonly IAmazonSQS _amazonSQS;
        //public GetNameController(IAmazonSQS amazonSQS)
        //{
        //    _amazonSQS = amazonSQS;
        //}
        // [HttpGet]
        //public IEnumerable<Employee> Get()
        //{
        //    var request = new ReceiveMessageRequest
        //    {
        //        // MessageBody = JsonSerializer.Serialize(emp),

        //        MaxNumberOfMessages= 10,
        //        WaitTimeSeconds=10,


        //        QueueUrl = ""
        //    };
        //    var req= _amazonSQS.ReceiveMessageAsync(request).Result;
        //    var emplist = new List<Employee>();
        //    foreach (var item in req.Messages)
        //    {
        //      var m=  JsonSerializer.Deserialize<Employee>(item.Body);
        //        emplist.Add(m);
        //    }

        //    return emplist;

        //}
        //[HttpPost]
        //public IActionResult Post(Employee emp)
        //{
        //    var request = new SendMessageRequest
        //    {
        //        MessageBody = JsonSerializer.Serialize(emp),
        //        QueueUrl = ""
        //    };
        //    _amazonSQS.SendMessageAsync(request).Wait();
        //    return NoContent(); 


        //}
      
        [HttpPost]
        public IActionResult Post(Employee emp)
        {
            var credentials = new BasicAWSCredentials("", "");
            var client = new AmazonSQSClient(credentials, RegionEndpoint.USEast1);

            var request = new SendMessageRequest
            {

                MessageBody = JsonSerializer.Serialize(emp),
                QueueUrl = ""
            };
            client.SendMessageAsync(request).Wait();
            return NoContent();
        }

        [HttpGet]
        public IEnumerable<Employee> Get()
        {
            var credentials = new BasicAWSCredentials("", "");
            var client = new AmazonSQSClient(credentials, RegionEndpoint.USEast1);

            var request = new ReceiveMessageRequest
            {
                // MessageBody = JsonSerializer.Serialize(emp),

                MaxNumberOfMessages = 10,
                WaitTimeSeconds = 10,
                QueueUrl = ""
            };
            var req = client.ReceiveMessageAsync(request).Result;
            var emplist = new List<Employee>();
            foreach (var item in req.Messages)
            {
                var m = JsonSerializer.Deserialize<Employee>(item.Body);
                emplist.Add(m);

            }
            return emplist;
        }
    }
}
