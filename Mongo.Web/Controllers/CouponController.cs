﻿using Microsoft.AspNetCore.Mvc;
using Mongo.Web.Models;
using Mongo.Web.Service.IService;
using Newtonsoft.Json;

namespace Mongo.Web.Controllers
{
    public class CouponController : Controller
    {
        private readonly ICouponService _couponService;
        public CouponController(ICouponService couponService)
        {
            this._couponService = couponService;
        }


        [HttpGet]
        public async Task<IActionResult> CouponIndex()
        {
            List<CouponDto>? List = new();

            ResponseDto? responseDto=await _couponService.GetAllCouponsAsync();

            if (responseDto != null && responseDto.IsSuccess)
            {

                List = JsonConvert.DeserializeObject<List<CouponDto>>(responseDto.Result.ToString());
            }else
            {
                TempData["error"] = responseDto?.Message;
            }

            return View(List);
        }

        public async Task<IActionResult> CouponCreate()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> CouponCreate(CouponDto model)
        {
            if (ModelState.IsValid) {
                    ResponseDto? response= await _couponService.CreateCouponsAsync(model);
                if (response != null && response.IsSuccess) {
                    TempData["success"] = "Coupon created successfully";
                    return RedirectToAction(nameof(CouponIndex));
                }
                else
                {
                    TempData["error"] = response?.Message;
                }
            }
            return View(model);
        }

        public async Task<IActionResult> CouponDelete(int couponId)
        {
            ResponseDto? response = await _couponService.GetCouponByIdAsync(couponId);

            if (response != null && response.IsSuccess)
            {
                CouponDto? model = JsonConvert.DeserializeObject<CouponDto>(Convert.ToString(response.Result));
                return View(model);
            }
            else
            {
                TempData["error"] = response?.Message;
            }
            return NotFound();
        }


        [HttpPost]
        public async Task<IActionResult> CouponDelete(CouponDto couponDto)
        {
            ResponseDto? response = await _couponService.DeleteCouponsAsync(couponDto.CouponId);

            if (response != null && response.IsSuccess)
            {
                TempData["success"] = "Coupon deleted successfully";
                return RedirectToAction(nameof(CouponIndex));
            }
            else
            {
                TempData["error"] = response?.Message;
            }
            return View(couponDto);
        }
    }
}
