using Shopping_Cart.Models;

namespace Shopping_Cart.Services
{
    public interface IBill
    {
        bool GenerateBill(BillMaster bill, BillDetail[] details);
    }
}