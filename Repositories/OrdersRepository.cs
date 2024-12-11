﻿using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class OrdersRepository : IOrdersRepository
    {
        MyShop0331Context _context;

        public OrdersRepository(MyShop0331Context context)
        {
            _context = context;
        }

        //Get
        public async Task<Order> GetById(int id)
        {
            List<Order> allCategories = await _context.Orders.Include(c => c.User).ToListAsync<Order>();
            return await _context.Orders.FirstOrDefaultAsync(order => order.OrderId == id);
        }

        //Post
        public async Task<Order> AddOrder(Order order)
        {
            await _context.Orders.AddAsync(order);
            await _context.SaveChangesAsync();
            return order;
        }
    }
}