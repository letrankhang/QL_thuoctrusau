using QL_CuaHangBanThuocTruSau.DAO;
using QL_CuaHangBanThuocTruSau.Models;
using System.Collections.Generic;

namespace QL_CuaHangBanThuocTruSau.BUS
{
    public class ProductBUS
    {
        private readonly ProductDAO _productDAO = new ProductDAO();

        public List<ProductVariant> SearchProducts(string keyword)
        {
            if (string.IsNullOrWhiteSpace(keyword)) return new List<ProductVariant>();
            return _productDAO.SearchProductVariants(keyword);
        }

        public ProductVariant GetVariantById(int id)
        {
            return _productDAO.GetVariantById(id);
        }
    }
}