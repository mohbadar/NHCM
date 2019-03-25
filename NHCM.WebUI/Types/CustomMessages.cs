using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NHCM.WebUI.Types
{
    public class CustomMessages
    {
        public static string InternalSystemException { get; } = "کاربر محترم درخواست شما مواجه با مشکل تخنیکی میباشد. لطفا با مسول سیستم به تماس شوید";
        public static string ValidationException { get; } = "اطلاعات فورم درست نمیباشد";

    }
}
