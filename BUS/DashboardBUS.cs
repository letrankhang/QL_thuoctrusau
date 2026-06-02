using QL_CuaHangBanThuocTruSau.DAO;

namespace QL_CuaHangBanThuocTruSau.BUS 
{
    public class DashboardBUS 
    {
        private DashboardDAO _dashboardDAO;

        public DashboardBUS () 
        {
            _dashboardDAO = new DashboardDAO ();
        }

        public dynamic GetRevenueData () 
        {
            return _dashboardDAO.GetRevenueLast7Days ();
        }

        public dynamic GetExpiredProducts () 
        {
            return _dashboardDAO.GetNearingExpiryProducts (30); 
        }

        public dynamic GetSummary () 
        {
            return _dashboardDAO.GetDashboardSummary ();
        }
    }
}
