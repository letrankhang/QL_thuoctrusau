using QL_CuaHangBanThuocTruSau.BUS;

namespace QL_CuaHangBanThuocTruSau.Controllers {
    public class DashboardController {
        private readonly DashboardBUS _dashboardBUS;

        public DashboardController () {
            _dashboardBUS = new DashboardBUS ();
        }

        public dynamic GetRevenueData () {
            return _dashboardBUS.GetRevenueData ();
        }

        public dynamic GetExpiredProducts () {
            return _dashboardBUS.GetExpiredProducts ();
        }

        public dynamic GetSummary () {
            return _dashboardBUS.GetSummary ();
        }
    }
}
