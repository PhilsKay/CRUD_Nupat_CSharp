using Microsoft.AspNetCore.Mvc;
using Nupat_CSharp.Models;
using Nupat_CSharp.Service;
using Nupat_CSharp.ViewModel;
using System.Diagnostics;

namespace Nupat_CSharp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IJobService _jobService;

        public HomeController(ILogger<HomeController> logger,IJobService jobService)
        {
            _logger = logger;
            _jobService = jobService;   
        }

        public async Task<IActionResult> Index()
        {
            var jobs = await _jobService.GetJobs();   
            return View(jobs);
        }

        public IActionResult Add()
        {
            return View();
        }


        public async Task<IActionResult> AddJob(JobViewModel obj)
        {
            if(ModelState.IsValid)
            {
                var job = await _jobService.AddJob(obj);
                return RedirectToAction("Index", job);
            }

            return View("Add",obj);
        }

        // Go to delete page 
        public async Task<IActionResult> Delete(Guid Id)
        {
            var result = await _jobService.GetJobById(Id); 
            
            return View(result);
        }

        // Delete the Job
        public async Task<IActionResult> DeleteJob(Job job)
        {
            await _jobService.DeleteJob(job);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Edit(Guid Id)
        {
            var result = await _jobService.GetJobById(Id);

            return View(result);
        }

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