using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StockMusicMasters.Areas.Admin.Views.AdminHome
{
    public class ManageAdminNav
    {
        public static string Index => "Index";

        public static string AddSong => "Add Song";

        public static string EditSong => "Edit Song";

        public static string ManageSongs => "Manage Songs";

        public static string IndexNavClass(ViewContext viewContext) => PageNavClass(viewContext, Index);

        public static string AddSongNavClass(ViewContext viewContext) => PageNavClass(viewContext, AddSong);

        public static string EditSongNavClass(ViewContext viewContext) => PageNavClass(viewContext, EditSong);

        public static string ManageSongsNavClass(ViewContext viewContext) => PageNavClass(viewContext, ManageSongs);

        private static string PageNavClass(ViewContext viewContext, string page)
        {
            var activePage = viewContext.ViewData["ActivePage"] as string
                ?? System.IO.Path.GetFileNameWithoutExtension(viewContext.ActionDescriptor.DisplayName);
            return string.Equals(activePage, page, StringComparison.OrdinalIgnoreCase) ? "active" : null;
        }
    }
}
