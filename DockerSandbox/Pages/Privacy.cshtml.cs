﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DockerSandbox.Pages
{
    public class PrivacyModel : PageModel
    {
        private readonly ILogger<PrivacyModel> loggerCopy;

        public PrivacyModel(ILogger<PrivacyModel> logger)
        {
            loggerCopy = logger;
        }

        public void OnGet()
        {
        }
    }
}
