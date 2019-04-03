using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NHCM.Application.Lookup.Queries;
using NHCM.Domain.Entities;
using NHCM.WebUI.Types;


namespace NHCM.WebUI.APIs
{
    [Route("api/[controller]")]
    [ApiController]
    public class ScreensController : ControllerBase
    {
        private IMediator _mediator;
        public ScreensController(IMediator mediator)
        {
            _mediator = mediator;
        }


        [HttpGet]
        public async Task<IActionResult> GetScreens(GetScreens command)
        {
            try
            {
                List<Screens> screens = new List<Screens>();
                screens = await _mediator.Send(command);
                return new JsonResult(new NHCM.WebUI.Types.UIResult()
                {
                    Data = new { list = screens },
                    Status =NHCM.WebUI.Types. UIStatus.Success,
                    Description = string.Empty,
                    Text = string.Empty
                });
            }
            catch(Exception ex)
            {
                return new JsonResult(new NHCM.WebUI.Types. UIResult()
                {
                    Data = null,
                    Status = NHCM.WebUI.Types.UIStatus.Failure,
                    Text = CustomMessages.InternalSystemException,
                    Description = ex.Message + "\n StackTrace: " + ex.StackTrace
                });
            }
        }

        public async void GetSubScreens([FromBody] int ParentID)
        {
            //try
            //{
            //    List<Screens> screens = new List<Screens>();
            //    screens = await _mediator.Send(new GetScreensByParentID() { ID = ParentID });
            //    return new JsonResult(new UIResult()
            //    {
            //        Data = new { list = screens },
            //        Status = UStatus,
            //        Text = string.Empty,
            //        Description = string.Empty
            //    });
            //}
            //catch(Exception ex)
            //{
            //    return new JsonResult(new UIResult()
            //    {
            //        Data = null,
            //        Status = UStatus,
            //        Text = CustomMessages.InternalSystemException,
            //        Description = ex.Message + "\n StackTrace: " + ex.StackTrace
            //    });
            //}
          
        }
    }
}