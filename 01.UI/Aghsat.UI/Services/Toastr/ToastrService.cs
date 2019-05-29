using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Aghsat.UI
{
    public static class ToastrService
    {
        private static readonly List<(DateTime Date, string SessionId, Toastr Toastr)> _toastrs =
            new List<(DateTime Date, string SessionId, Toastr Toastr)>();

        private static string GetSessionId()
        {
            return HttpContext.Current.Session.SessionID;
        }

        public static void AddToUserQueue(Toastr toastr)
        {
            _toastrs.Add((Date: DateTime.Now, SessionId: GetSessionId(), Toastr: toastr));
        }

        public static void AddToUserQueue(string message, string title, ToastrType type)
        {
            AddToUserQueue(new Toastr(message, title, type));
        }

        public static bool HasUserQueue()
        {
            string sessionId = GetSessionId();
            return _toastrs.Any(x => x.SessionId == sessionId);
        }

        public static void RemoveUserQueue()
        {
            string sessionId = GetSessionId();
            _toastrs.RemoveAll(x => x.SessionId == sessionId);
        }

        public static void ClearAll()
        {
            _toastrs.Clear();
        }

        public static List<(DateTime Date, string SessionId, Toastr Toastr)> ReadUserQueue()
        {
            string sessionId = GetSessionId();
            return _toastrs.Where(x => x.SessionId == sessionId).OrderBy(x => x.Date).ToList();
        }

        public static List<(DateTime Date, string SessionId, Toastr Toastr)> ReadAndRemoveUserQueue()
        {
            var list = ReadUserQueue();
            RemoveUserQueue();

            return list;
        }

        public static string ToJavascript(List<(DateTime Date, string SessionId, Toastr Toastr)> list)
        {
            var toastrsJsStrings = list.Select(x => x.Toastr.ToJavascript());
            return string.Join("", toastrsJsStrings);
        }

        public static void SetMessage(ToastrType type, string Message = "")
        {
            switch (type)
            {
                case ToastrType.Success:
                    ToastrService.AddToUserQueue(new Toastr(message: Message, type: ToastrType.Success));

                    break;

                case ToastrType.Info:
                    ToastrService.AddToUserQueue(new Toastr(message: Message, type: ToastrType.Info));

                    break;

                case ToastrType.Error:
                    ToastrService.AddToUserQueue(new Toastr(message: Message, type: ToastrType.Error));

                    break;

                case ToastrType.Warning:
                    ToastrService.AddToUserQueue(new Toastr(message: Message, type: ToastrType.Warning));

                    break;

            }


        }
    }
}
