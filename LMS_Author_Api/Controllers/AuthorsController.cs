using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using LibraryReact.Services;
using LibraryReact.Models;
using System;
using Microsoft.AspNetCore.Http;

namespace LibraryReact.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {
        private readonly IAuthorsServices _authorServices;

        public AuthorsController(IAuthorsServices authorServices)
        {
            _authorServices = authorServices;
        }

        [HttpGet("GetAuthors/")]
        public async Task<ActionResult<IEnumerable<Author>>> GetAuthors()
        {
            try
            {
                return (await _authorServices.GetAuthors()).ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpGet("GetAuthorById/{id}")]
        public async Task<ActionResult<Author>> GetAuthorById(string id)
        {

            try
            {
                var result = await _authorServices.GetAuthorById(id);

                if (result == null)
                {
                    return NotFound();
                }

                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost("CreateAuthor/")]
        public async Task<ActionResult<Author>> CreateAuthor(Author authorObj)
        {
            string message = "faild";
            try
            {
                if (authorObj == null)
                    return BadRequest();

                var createAuthor = await _authorServices.CreateAuthor(authorObj);
                if (createAuthor != null)
                {
                    message = "success";
                }
                else
                {
                    message = "faild";
                }
            }
            catch (Exception)
            {
                return Ok(message);
            }
            return Ok(message);
        }

        [HttpPut("UpdateAuthor/")]
        public async Task<ActionResult<Author>> UpdateAuthor(Author authorObj)
        {
            string message = "";
            try
            {
                if (authorObj.AuthorID != authorObj.AuthorID)
                {
                    return BadRequest();
                }

                var employeeToUpdate = await _authorServices.UpdateAuthor(authorObj);

                if (employeeToUpdate == null)
                {
                    message = "faild";
                }
                else
                {
                    await _authorServices.UpdateAuthor(authorObj);
                    message = "success";
                }

            }
            catch (Exception)
            {
                return Ok(message);
            }
            return Ok(message);
        }

        [HttpDelete("DeleteAuthor/{id}")]
        public async Task<ActionResult<Author>> DeleteAuthor(string id)
        {
            string message = "";
            try
            {
                var Authordelete = await _authorServices.GetAuthorById(id);

                if (Authordelete == null)
                {
                    message = "faild";
                }
                else
                {
                    await _authorServices.DeleteAuthor(id);
                    message = "success";
                }

            }
            catch (Exception)
            {
                message = "unable to delete";
                return Ok(message);
            }
            return Ok(message);
        }

    }
}
