﻿using Microsoft.AspNetCore.Mvc;
using ProgrammingClass4.MvcLesson.Data;
using Microsoft.EntityFrameworkCore;
using ProgrammingClass4.MvcLesson.Models;

namespace ProgrammingClass4.MvcLesson.Controllers
{
    [Route("ProductColors")]
    public class ProductColorsController : Controller
    {
        private readonly ApplicationDbContext _dbContext;
        public ProductColorsController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet("{productId}")]
        public IActionResult Index(int productId)
        {
            var productColors = _dbContext
                .ProductColors
                .Where(productColor => productColor.ProductId == productId)
                .Include(productColor => productColor.Color)
                .ToList();

            ViewBag.Colors = _dbContext.Colors.ToList();// viewbagi mejenq dnum dropdowni hamar 
            ViewBag.Product = _dbContext.Products.Find(productId);

            return View(productColors);
        }

        [HttpPost]
        public IActionResult Create(ProductColor productColor)
        {
            _dbContext.ProductColors.Add(productColor);
            _dbContext.SaveChanges();

            return RedirectToAction("Index", new { productId = productColor.ProductId });//?
        }
    }
}