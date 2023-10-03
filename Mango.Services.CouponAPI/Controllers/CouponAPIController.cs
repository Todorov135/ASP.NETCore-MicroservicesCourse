namespace Mango.Services.CouponAPI.Controllers
{
    using AutoMapper;
    using Mango.Services.CouponAPI.Data;
    using Mango.Services.CouponAPI.Models;
    using Mango.Services.CouponAPI.Models.Dto;
    using Microsoft.AspNetCore.Mvc;

    [Route("api/coupon")]
    [ApiController]
    public class CouponAPIController : ControllerBase
    {
        private readonly AppDbContex _db;
        private ResponceDto _responce;
        private IMapper _mapper;

        public CouponAPIController(AppDbContex db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
            _responce = new ResponceDto();
        }

        [HttpGet]
        public ResponceDto Get()
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
        public ResponceDto Get(int id)
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
        public ResponceDto GetByCode(string code)
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
        public ResponceDto Post([FromBody] CouponDto couponDto)
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
        public ResponceDto Put([FromBody] CouponDto couponDto)
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
        public ResponceDto Delete(int id)
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
