namespace Mango.Services.CouponAPI.Controllers
{
    using AutoMapper;
    using Mango.Services.CouponAPI.Data;
    using Mango.Services.CouponAPI.Models;
    using Mango.Services.CouponAPI.Models.Dto;
    using Mango.Services.CouponAPI.Utility;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [Route("api/coupon")]
    [ApiController]
    [Authorize]
    public class CouponAPIController : ControllerBase
    {
        private readonly AppDbContex _db;
        private ResponseDto _responce;
        private IMapper _mapper;

        public CouponAPIController(AppDbContex db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
            _responce = new ResponseDto();
        }

        [HttpGet]
        public ResponseDto Get()
        {
            try
            {
                IEnumerable<CouponDto> objList = _db.Coupons
                                                    .Select(c => _mapper.Map<CouponDto>(c))
                                                    .ToList();
                _responce.Result = objList;
            }
            catch (Exception ex)
            {
                _responce.IsSuccess = false;
                _responce.Message = ex.Message;
            }
            return _responce;
        }

        [HttpGet]
        [Route("{id:int}")]
        public ResponseDto Get(int id)
        {
            try
            {
                Coupon obj = _db.Coupons.First(c => c.CouponId == id);
                _responce.Result = _mapper.Map<CouponDto>(obj);
            }
            catch (Exception ex)    
            {
                _responce.IsSuccess = false;
                _responce.Message = ex.Message;
            }
            return _responce;
        }

        [HttpGet]
        [Route("GetByCode/{code}")]
        public ResponseDto GetByCode(string code)
        {
            try
            {
                Coupon obj = _db.Coupons.First(c => c.CouponCode.ToLower() == code.ToLower());
                _responce.Result = _mapper.Map<CouponDto>(obj);
            }
            catch (Exception ex)
            {
                _responce.IsSuccess = false;
                _responce.Message = ex.Message;
            }
            return _responce;
        }

        [HttpPost]
        [Authorize(Roles = SD.RoleAdmin)]
        public ResponseDto Post([FromBody] CouponDto couponDto)
        {
            try
            {
                Coupon coupon = _mapper.Map<Coupon>(couponDto);
                _db.Coupons.Add(coupon);
                _db.SaveChanges();

                _responce.Result = _mapper.Map<CouponDto>(coupon);
            }
            catch (Exception ex)
            {
                _responce.IsSuccess = false;
                _responce.Message = ex.Message;
            }
            return _responce;
        }

        [HttpPut]
        [Authorize(Roles = SD.RoleAdmin)]
        public ResponseDto Put([FromBody] CouponDto couponDto)
        {
            try
            {
                Coupon coupon = _mapper.Map<Coupon>(couponDto);
                _db.Coupons.Update(coupon);
                _db.SaveChanges();

                _responce.Result = _mapper.Map<CouponDto>(coupon);
            }
            catch (Exception ex)
            {
                _responce.IsSuccess = false;
                _responce.Message = ex.Message;
            }
            return _responce;
        }

        [HttpDelete]
        [Route("{id:int}")]
        [Authorize(Roles = SD.RoleAdmin)]
        public ResponseDto Delete(int id)
        {
            try
            {
                Coupon coupon = _db.Coupons.First(c => c.CouponId == id);
                _db.Coupons.Remove(coupon);
                _db.SaveChanges();
            }
            catch (Exception ex)
            {
                _responce.IsSuccess = false;
                _responce.Message = ex.Message;
            }
            return _responce;
        }



    }
}
