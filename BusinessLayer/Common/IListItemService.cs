
using System.Web.Mvc;
using Entities.ListItem;

namespace BusinessLayer.Common;

public interface IListItemService
{
    Task<List<SelectListItem>> GetListItemDropDown(string listId);
}