using ShopBridge.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace ShopBridge.Controllers
{
    public class ProductsWebApiController : ApiController
    {

        // GET api/<controller>
        [HttpGet, Route("api/ProductsWebApi/GetProductById")]
        public async Task<IHttpActionResult> GetProductById(int id)
        {
            try
            {
                if (string.IsNullOrEmpty(Convert.ToString(id)))
                {
                    throw new Exception("Item id is not valid !");
                }
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                Product CurrObj =await Task.Run(() => GetProductByIdFromServer(id));
                if (CurrObj.ErrorMsg == "Exception")
                {
                    return BadRequest("Error occurred. Please contact system administrator");
                }
                else
                {
                    return Ok();
                }
            }
            catch (Exception e) { 
                return BadRequest("Error occurred. Please contact system administrator"+e.Message);
            }
        }
        public Product GetProductByIdFromServer(int id)
        {
            try
            {
                Product CurrObj = ProductDAL.GetProductById(id);
                CurrObj.ErrorMsg = "Success";
                return CurrObj;
            }
            catch (Exception ex)
            {
                Product CurrObj = new Product();
                CurrObj.ErrorMsg = "Exception";
                return CurrObj;
            }
        }
        /// <summary>
        ///Action: Update Product
        /// </summary>
        /// <param name="product">Object of Product</param>
        /// <returns></returns>
        [HttpPost, Route("api/ProductsWebApi/Update")]
        public async Task<IHttpActionResult> UpdateProduct([FromBody] Product product)
        {
            if (product==null)
            {
                throw new Exception("Item is not valid !");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                Product CurrObj = await Task.Run(() => UpdateProductFromServer(product.id, product));
                if (CurrObj.ErrorMsg == "Exception")
                {
                    return BadRequest("Error occurred. Please contact system administrator");
                }
                else
                {
                    return Ok();
                }
            



            }
            catch (Exception e)
            {
               return BadRequest("Error occurred. Please contact system administrator" + e.Message);
            }
        }
        public Product UpdateProductFromServer(int id,Product product)
        {
            try
            {
                ProductDAL.Edit(id, product);
                product.ErrorMsg = "Success";
                return product;
            }
            catch (Exception ex)
            {
                Product CurrObj = new Product();
                CurrObj.ErrorMsg = "Exception";
                return CurrObj;
            }
        }
        // GET api/<controller>/5


        // POST api/<controller>
        [HttpPost, Route("api/ProductsWebApi/Delete")]
        public async Task<IHttpActionResult> DeleteProduct(int id)
        {
            try
            {
                if (string.IsNullOrEmpty(Convert.ToString(id)))
                {
                    throw new Exception("Item id is not valid !");
                }

                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                Product CurrObj = await Task.Run(() => DeleteProductByIdFromServer(id));
                if (CurrObj.ErrorMsg == "Exception")
                {
                    return BadRequest("Error occurred. Please contact system administrator");
                }
                else
                {
                    return Ok();
                }
            }
            catch (Exception e) {
                return BadRequest("Error occurred. Please contact system administrator" + e.Message);
            }
        }

        public Product DeleteProductByIdFromServer(int id)
        {
            try
            {
                Product CurrObj = new Product();
                 ProductDAL.DeleteProduct(id);
                CurrObj.ErrorMsg = "Success";
                return CurrObj;
            }
            catch (Exception ex)
            {
                Product CurrObj = new Product();
                CurrObj.ErrorMsg = "Exception";
                return CurrObj;
            }
        }
        [HttpPost, Route("api/ProductsWebApi/Add")]
        public async Task<IHttpActionResult> Add([FromBody] Product product)
        {
            if (product == null)
            {
                throw new Exception("Item is not valid !");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                Product CurrObj = await Task.Run(() => AddProductFromServer(product));
                if (CurrObj.ErrorMsg == "Exception")
                {
                    return BadRequest("Error occurred. Please contact system administrator");
                }
                else
                {
                    return Ok();
                }

            }
            catch (Exception e)
            {
                return BadRequest("Error occurred. Please contact system administrator" + e.Message);
            }
        }


        public Product AddProductFromServer(Product product)
        {
            try
            {
                Product CurrObj = new Product();
                ProductDAL.AddProduct(product);
                CurrObj.ErrorMsg = "Success";
                return CurrObj;
            }
            catch (Exception ex)
            {
                Product CurrObj = new Product();
                CurrObj.ErrorMsg = "Exception";
                return CurrObj;
            }
        }
    }
}