﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ScrabbleHelper;
using System.Collections.Generic;

namespace ScrabbleHelperBackend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ScrabbleHelperWordsController : ControllerBase
    {
        private readonly ScrabbleHelperCommon scrabbleHelperCommon;
        private readonly ILogger<ScrabbleHelperWordsController> _logger;

        public ScrabbleHelperWordsController(ILogger<ScrabbleHelperWordsController> logger)
        {
            scrabbleHelperCommon = new ScrabbleHelperCommon();
            _logger = logger;
        }

        [HttpGet]
        public Dictionary<int, string> Get(string letters)
        {
            _logger.LogInformation("ScrabbleHelperWordsController - GET request received");
            var foundWords = scrabbleHelperCommon.SearchWords(letters);

            return foundWords;
        }
    }
}
