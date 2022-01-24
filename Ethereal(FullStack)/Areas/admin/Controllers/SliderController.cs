using Ethereal_FullStack_.Data;
using Ethereal_FullStack_.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Ethereal_FullStack_.Areas.admin.Controllers
{
    [Area("admin")]
    public class SliderController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public SliderController(AppDbContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
        }
        public IActionResult Index()
        {
            return View(_context.Sliders.ToList());
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Slider model)
        {
            if (ModelState.IsValid)
            {
                if (model.ImageFile.ContentType=="image/jpeg" || model.ImageFile.ContentType=="image/png")
                {
                    if (model.ImageFile.Length <= 3145728)
                    {
                        string fileName = Guid.NewGuid() + "-" + model.ImageFile.FileName;
                        string filePath = Path.Combine(_webHostEnvironment.WebRootPath, "Uploads", fileName);

                        using (var stream = new FileStream(filePath, FileMode.Create))
                        {
                            model.ImageFile.CopyTo(stream);
                        }

                        model.Image = fileName;
                        _context.Sliders.Add(model);
                        _context.SaveChanges();

                        return RedirectToAction("index");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Please Upload max 3MB Image file!");
                        return View(model);
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Please upload only Image File!");
                }
            }
            else
            {
                return View(model);
            }
            return View();
        }

        public IActionResult Update(int? id)
        {
            return View(_context.Sliders.Find(id));
        }

        [HttpPost]
        public IActionResult Update(Slider model)
        {
            if (ModelState.IsValid)
            {
                if (model.ImageFile != null)
                {
                    if (model.ImageFile.ContentType == "image/jpeg" || model.ImageFile.ContentType == "image/png")
                    {
                        if (model.ImageFile.Length <= 3145728)
                        {
                            string oldImagePath = Path.Combine(_webHostEnvironment.WebRootPath, "Uploads", model.Image);
                            if (System.IO.File.Exists(oldImagePath))
                            {
                                System.IO.File.Delete(oldImagePath);
                            }

                            string fileName = Guid.NewGuid() + "-" + model.ImageFile.FileName;
                            string filePath = Path.Combine(_webHostEnvironment.WebRootPath, "Uploads", fileName);

                            using (var stream = new FileStream(filePath, FileMode.Create))
                            {
                                model.ImageFile.CopyTo(stream);
                            }

                            model.Image = fileName;

                            _context.Sliders.Update(model);
                            _context.SaveChanges();

                            return RedirectToAction("index");
                        }
                        else
                        {
                            ModelState.AddModelError("", "You can only upload max 3 mb file!");
                            return View(model);
                        }
                    }
                    else
                    {
                        ModelState.AddModelError("", "You can only upload image file!");
                        return View(model);
                    }
                }
                else
                {
                    _context.Sliders.Update(model);
                    _context.SaveChanges();
                    return RedirectToAction("index");
                }
            }
            else
            {
                return View(model);
            }
        }

        public IActionResult Delete(int? id)
        {
            if (id==null)
            {
                return NotFound();
            }

            Slider slider = _context.Sliders.Find(id);
            if (slider==null)
            {
                return NotFound();
            }

            string filePath = Path.Combine(_webHostEnvironment.WebRootPath, "Uploads", slider.Image);
            if (System.IO.File.Exists(filePath))
            {
                System.IO.File.Delete(filePath);
            }
            _context.Sliders.Remove(slider);
            _context.SaveChanges();
            return RedirectToAction("index");
        }
    }
}
