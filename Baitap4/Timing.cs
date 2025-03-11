using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baitap3._3
{
    class Timing
    {
        TimeSpan startingtime; //Cài đặt biến lưu bắt đầu
        TimeSpan duration; //Cài đặt biến lưu khoảng thời gian thực thi 
                           // TimeSpan là bộ đếm biểu diễn và tính toán thời gian

        public Timing()
        {
            startingtime = new TimeSpan(0); //Khởi tạo giá trị mặc định ban đầu
            duration = new TimeSpan(0); //Khởi tạo giá trị mặc định ban đầu
        }
        public void StopTime()
        {
            duration = Process.GetCurrentProcess().Threads[0].
            UserProcessorTime.
            Subtract(startingtime);
        }
        public void StartTime()
        {
            GC.Collect();
            GC.WaitForPendingFinalizers();
            startingtime = Process.GetCurrentProcess().Threads[0].
            UserProcessorTime;
        }
        public TimeSpan Result()
        {
            return duration;
        }
    }
}


