﻿using FirstWebApi.Models;
using FirstWebApi.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;

namespace FirstWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        private readonly IConfiguration configuration;
        private readonly IAccountService accountService;

        public TestController(IConfiguration configuration, IAccountService accountService)
        {
            this.configuration = configuration;
            this.accountService = accountService;
        }

        [HttpGet]
        [Route("GetMessage")]
        public async Task<IActionResult> GetMessage()
        {
            return Ok("Hello, Welcome to first api endpoint.");
        }

        [HttpGet]
        [Route("GetMessage2")]
        public async Task<IActionResult> GetMessage2(string message)
        {
            return Ok("Hello," + message);
        }

        [HttpGet]
        [Route("GetMessage3/{message}")]
        public async Task<IActionResult> GetMessage3([FromRoute]string message)
        {
            return Ok("Hello," + message);
        }

        [HttpGet]
        [Route("GetMessage3/{message1}/{message2}")]
        public async Task<IActionResult> GetMessage3([FromRoute] string message1, [FromRoute] string message2)
        {
            return Ok("Hello," + message1+" "+ message2);
        }


        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> LoginAsync(LoginRequest loginRequest)
        {
            var response = await accountService.LoginAsync(loginRequest);

            return Ok(response);
        }

    }
}