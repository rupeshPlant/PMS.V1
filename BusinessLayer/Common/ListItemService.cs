
using System.Web.Mvc;
using Data;
using Entities.ListItem;
using Microsoft.EntityFrameworkCore;

namespace BusinessLayer.Common;

public class ListItemService : IListItemService
{
    private readonly DataContext _context;

    public ListItemService(DataContext context)
    {
        _context = context;
    }
    
    public async Task<List<SelectListItem>> GetListItemDropDown(string listId)
    {
        var list = await _context.ListItem.Where(v => v.ListItemId == listId).Select(x => new SelectListItem
        {
            Value = x.ListItemId,
            Text = x.ListItemName
        }).ToListAsync();
        return list;
    }
}