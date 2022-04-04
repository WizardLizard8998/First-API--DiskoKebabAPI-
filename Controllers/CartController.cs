namespace projectServices.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using System.Collections.Generic;
    using System.Linq;
    using projectServices.Context;
    using projectServices.Models;

    [Route("api/[controller]")]
    [ApiController]

    public class CartController : ControllerBase
    {
        private CartContext _cartContext;

        public CartController(CartContext cartContext)
        {
            _cartContext = cartContext;
        }

        [HttpGet]
        //Get : api/<CartController>
        public IEnumerable<Cart> Get()
        {
            return _cartContext.Cart;
        }

        [HttpGet("{Phone}")]
        //Get : api/<CarController>/Phone
        public Cart Get(string Phone)
        {
            return _cartContext.Cart.FirstOrDefault(s => s.Phone == Phone);
        }

        [HttpPost]
        //POST : api/<CartController>/Phone
        public void Post([FromBody] Cart value)
        {
            _cartContext.Cart.Add(value);
            _cartContext.SaveChanges();
        }

        [HttpPut("{Phone}")]
        //PUT : api/<CartController>/Phone
        public void Put(string Phone, [FromBody] Cart value)
        {

            var tempCart = _cartContext.Cart.FirstOrDefault(s => s.Phone == Phone);

            if (tempCart != null)
            {
                _cartContext.Entry<Cart>(tempCart).CurrentValues.SetValues(value);
                _cartContext.SaveChanges();
            }
        }

        [HttpDelete("{Phone}")]

        public void Delete(string Phone)
        {
            var tempCart = _cartContext.Cart.FirstOrDefault(s => s.Phone == Phone);

            if (tempCart != null)
            {
                _cartContext.Cart.Remove(tempCart);
                _cartContext.SaveChanges();
            }
        }


    }

}