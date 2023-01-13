using System;
using ElearningPortal.Models;
using ElearningPortal.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ElearningPortal.Controllers.User
{
	public class DeleteUserController
	{
        private readonly IDeleteUserService _deleteUserService;

        public DeleteUserController(IDeleteUserService deleteUserService)
        {
            _deleteUserService = deleteUserService;
        }
        
        [HttpDelete]
        [Route("api/deleteuser/{UserId}"), Authorize(Policy = "RequireAdministratorRole")]
        public Task<string> DeleteUser(int UserId)
		{
            var reponse = _deleteUserService.DeleteUser(UserId);
            return reponse;
		}
    }
}

