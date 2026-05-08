using QL_CuaHangBanThuocTruSau.DAO;
using System.Collections.Generic;

namespace QL_CuaHangBanThuocTruSau.BUS {
    public class DashboardBUS {
        private readonly DashboardDAO _dashboardDAO;

        public DashboardBUS () {
            _dashboardDAO = new DashboardDAO ();
        }

        public dynamic GetRevenueData () {
            return _dashboardDAO.GetRevenueLast7Days ();
        }

        public dynamic GetExpiredProducts () {
            return _dashboardDAO.GetNearingExpiryProducts (30); // Mặc định 30 ngày
        }

        public dynamic GetSummary () {
            return _dashboardDAO.GetDashboardSummary ();
        }
    }
}
