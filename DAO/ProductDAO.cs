using QL_CuaHangBanThuocTruSau.Context;
using QL_CuaHangBanThuocTruSau.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace QL_CuaHangBanThuocTruSau.DAO
{
    public class ProductDAO
    {
        public ProductDAO() { }

        public List<ProductVariant> SearchProductVariants(string keyword)
        {
            using (var context = new AppDbContext())
            {
                context.Configuration.ProxyCreationEnabled = false;
                return context.ProductVariants
                    .Include(pv => pv.Product)
                    .Where(pv => pv.Product.Name.Contains(keyword) || pv.Unit.Contains(keyword))
                    .AsNoTracking()
                    .ToList();
            }
        }

        public ProductVariant GetVariantById(int id)
        {
            using (var context = new AppDbContext())
            {
                context.Configuration.ProxyCreationEnabled = false;
                return context.ProductVariants
                    .Include(pv => pv.Product)
                    .FirstOrDefault(pv => pv.VariantID == id);
            }
        }
    }
}