using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Nupat_CSharp.Models;
using Nupat_CSharp.Service;
using Nupat_CSharp.Utility;
using Nupat_CSharp.ViewModel;
using System.Diagnostics;

namespace Nupat_CSharp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IJobService _jobService;
        private readonly ITest _test;


        public HomeController(ILogger<HomeController> logger,IJobService jobService, ITest test)
        {
            _logger = logger;
            _jobService = jobService; 
            _test = test;
        }


        [Authorize]
        public async Task<IActionResult> Index()
        {
            var jobs = await _jobService.GetJobs();   
            return View(jobs);
        }
        public IActionResult Test()
        {
            int value1 = _test.RandomNumber();
            int value2 = _test.RandomNumber();
            int value3 = _test.RandomNumber();
            TestViewModel test = new TestViewModel()
            {
                value_1 = value1,
                value_2 = value2,
                value_3 = value3
            };
            return View(test);
        }
        [Authorize(Roles ="Admin")]
        public IActionResult Add()
        {
            return View();
        }

        [Authorize(Roles = "Admin")]


        public async Task<IActionResult> AddJob(JobViewModel obj)
        {
            if(ModelState.IsValid)
            {
                var job = await _jobService.AddJob(obj);
                return RedirectToAction("Index", job);
            }

            return View("Add",obj);
        }

        [Authorize(Roles = "Admin")]


        // Go to delete page 
        public async Task<IActionResult> Delete(Guid Id)
        {
            var result = await _jobService.GetJobById(Id); 
            
            return View(result);
        }

        [Authorize(Roles = "Admin")]


        // Delete the Job
        public async Task<IActionResult> DeleteJob(Job job)
        {
            await _jobService.DeleteJob(job);
            return RedirectToAction("Index");
        }
        [Authorize(Roles = "Admin")]


        public async Task<IActionResult> Edit(Guid Id)
        {
            var result = await _jobService.GetJobById(Id);

            return View(result);
        }
        [Authorize(Roles = "Admin")]


        // Edit the Job
        public async Task<IActionResult> EditJob(Job job)
        {
            await _jobService.Edit(job);
            return RedirectToAction("Index");
        }




        public IActionResult Privacy()
        {
            
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}