using System;
using System.Collections.Generic;
using System.Text;

namespace CTMS.Common.Utility
{
    using CTMS.Common.Extension;
    public static partial class Utility
    {
        public static DateTime ToStartTime(object startTime)
        {
            try
            {
                string date = "1900-01-01";
                if (startTime == null)
                    return date.ToDate();
                string dateStartTime = startTime.ToString();
                if (string.IsNullOrWhiteSpace(dateStartTime))
                    return date.ToDate();
                else
                    return dateStartTime.ToDate();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public static DateTime ToEndTime(object endTime)
        {
            try
            {
                if (endTime == null)
                    return DateTime.Now.ToDate();
                string dateEndTime = endTime.ToString();
                return string.IsNullOrWhiteSpace(dateEndTime) ? DateTime.Now.ToDate() : dateEndTime.ToDate();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public static int ToTopTotal(int count)
        {
            try
            {
                int total = count <= 0 ? 10 : count;
                return total > 1000 ? 1000 : total;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public static int ToPageIndex(int pageId)
        {
            try
            {
                int pageIndex = pageId <= 0 ? 1 : pageId;
                return pageIndex > 1000 ? 1000 : pageIndex;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public static int ToPageCount(int pageSize)
        {
            try
            {
                int pageCount = pageSize <= 0 ? 10 : pageSize;
                return pageCount > 100 ? 100 : pageCount;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}
