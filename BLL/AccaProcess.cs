using System;
using System.Collections.Generic;
using System.Text;
using Irmac.MailingCycle.IDAL;
using Irmac.MailingCycle.Model;

namespace Irmac.MailingCycle.BLL
{
    public class AccaProcess
    {
        public List<AccaInfo> GetCreditCardDetailsForScheduledEvents(DateTime eventDate)
        {
            IAccaProcess dao = (IAccaProcess)DALFactory.DAO.Create(DALFactory.Module.AccaProcess);
            List<AccaInfo> allAccaInfo = dao.GetCreditCardDetailsForScheduledEvents(eventDate);
            foreach (AccaInfo accaInfo in allAccaInfo)
            {
                OrderInfo orderInfo = new OrderInfo();
                orderInfo.Amount = CalculateAmount(accaInfo);
                orderInfo.Type = OrderType.Event;
                accaInfo.AccaOrderInfo = orderInfo;
                List<InventoryInfo> inventoryInfo = new Order().GetInventoryList(accaInfo.UserId);
                bool isInvAvl = false;
                bool isInvCountNotAvl = false;
                if (accaInfo.EventStatus != ScheduleEventStatus.ACCAError)
                {
                    //Check for sufficient quantity
                    foreach (InventoryInfo invInfo in inventoryInfo)
                    {
                        //for brochure, check the availability of the same number of envelopes.
                        if ((invInfo.CategoryType.ToString() == accaInfo.AccaDesignCategory.ToString()) ||
                            (accaInfo.AccaDesignCategory != DesignCategory.PowerKard && invInfo.CategoryType == ProductCategory.Envelope))
                        {
                            isInvAvl = true;
                            if (invInfo.QuantityOnHand < accaInfo.ContactCount)
                            {
                                isInvCountNotAvl = true;
                                break;
                            }
                        }                
                    }
                }
                if (isInvCountNotAvl || !isInvAvl)
                {
                    accaInfo.EventStatus = ScheduleEventStatus.ACCAError;
                    if(accaInfo.AccaDesignCategory == DesignCategory.Brochure)
                        accaInfo.Remarks = "Required quantity of Brochures/Envelopes not available";                               
                    else
                        accaInfo.Remarks = "Required quantity of PowerKards not available";                               
                }                
            }
            return allAccaInfo;
        }

        public static decimal CalculateAmount(DesignCategory designCategory,
            string postalTariff, int mailQuantity)
        {
            decimal amount;
            decimal postage = Convert.ToDecimal(new Common().GetProperty("PostageStamps").Value);
            decimal bulkMail = Convert.ToDecimal(new Common().GetProperty("BulkMail").Value);

            if (postalTariff == "Postage Stamps")
            {
                amount = Convert.ToDecimal((mailQuantity * 0.41) + 25);
            }
            else
            {
                amount = Convert.ToDecimal((mailQuantity * 0.15) + 25);
            }

            if (designCategory == DesignCategory.PowerKard)
            {
                if (mailQuantity <= 1000)
                {
                    amount += Convert.ToDecimal(89 + (0.03 * mailQuantity));
                }
                else if (mailQuantity > 1000 && mailQuantity <= 2000)
                {
                    amount += Convert.ToDecimal(100 + (0.04 * mailQuantity));
                }
                else if (mailQuantity > 2000)
                {
                    amount += Convert.ToDecimal(124 + (0.04 * mailQuantity));
                }
            }

            return amount;
        }

        private decimal CalculateAmount(AccaInfo accaInfo)
        {
            return CalculateAmount(accaInfo.AccaDesignCategory, accaInfo.PostalTariff,
                accaInfo.ContactCount);
        }

        public List<AccaInfo> UpdateEventInfo(List<AccaInfo> eventsInfo)
        {
            IAccaProcess dao = (IAccaProcess)DALFactory.DAO.Create(DALFactory.Module.AccaProcess);
            return dao.UpdateEventInfo(eventsInfo);
        }
    }
}
