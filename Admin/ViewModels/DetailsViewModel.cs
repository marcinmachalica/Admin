using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Admin.Models;

namespace Admin.ViewModels
{
    public class DetailsViewModel
    {
        public string Id { get; set; }
        public string ComputerName { get; set; }
        public string UserName { get; set; }
        public string OsVersion { get; set; }
        public string Is64 { get; set; }
        public string ServicePack { get; set; }
        public string UserDomain { get; set; }
        public string LastUpdate { get; set; }
        public int TickCount { get; set; }
        public CPU Cpu { get; set; }
        public GPU Gpu { get; set; }
        //public Config config { get; set; }
        public Memory Memory { get; set; }
        public Motherboard Mb { get; set; }
        public HDD Hdd { get; set; }

        public DetailsViewModel(AdminModel adm)//,Config conf)
        {

            Cpu = new CPU();
            Gpu = new GPU();
            Memory = new Memory();
            Mb = new Motherboard();
            Hdd = new HDD();

            Id = adm._id;
            ComputerName = adm.Hardware.ComputerName;
            UserName = adm.Hardware.UserName;
            OsVersion = adm.Hardware.OsVersion;
            Is64 = adm.Hardware.Is64;
            ServicePack = adm.Hardware.ServicePack;
            UserDomain = adm.Hardware.UserDomain;
            LastUpdate = adm.Hardware.LastUpdate;
            TickCount = adm.Hardware.TickCount;
            Cpu.BusSpeed = adm.Hardware._cpu.BusSpeed;
            Cpu.CPUCoreClock = adm.Hardware._cpu.CPUCoreClock;
            Cpu.CPUCoreLoad = adm.Hardware._cpu.CPUCoreLoad;
            Cpu.CPUCoresPow = adm.Hardware._cpu.CPUCoresPow;
            Cpu.CPUCoreTemp = adm.Hardware._cpu.CPUCoreTemp;
            Cpu.CPUGraphicsPow = adm.Hardware._cpu.CPUGraphicsPow;
            Cpu.CPUName = adm.Hardware._cpu.CPUName;
            Cpu.CPUPackagePow = adm.Hardware._cpu.CPUPackagePow;
            Cpu.CPUPackageTemp = adm.Hardware._cpu.CPUPackageTemp;
            Cpu.CPUPowers = adm.Hardware._cpu.CPUPowers;
            Cpu.CPUTotalLoad = adm.Hardware._cpu.CPUTotalLoad;
            Cpu.Other = adm.Hardware._cpu.Other;
            Gpu.GPUClocks = adm.Hardware._gpu.GPUClocks;
            Gpu.GPUCore = adm.Hardware._gpu.GPUCore;
            Gpu.GPUCoreLoad = adm.Hardware._gpu.GPUCoreLoad;
            Gpu.GPUCoreTemp = adm.Hardware._gpu.GPUCoreTemp;
            Gpu.GPUData = adm.Hardware._gpu.GPUData;
            Gpu.GPULoads = adm.Hardware._gpu.GPULoads;
            Gpu.GPUMemory = adm.Hardware._gpu.GPUMemory;
            Gpu.GPUMemoryContLoad = adm.Hardware._gpu.GPUMemoryContLoad;
            Gpu.GPUMemoryFree = adm.Hardware._gpu.GPUMemoryFree;
            Gpu.GPUMemoryLoad = adm.Hardware._gpu.GPUMemoryLoad;
            Gpu.GPUMemoryTotal = adm.Hardware._gpu.GPUMemoryTotal;
            Gpu.GPUMemoryUsed = adm.Hardware._gpu.GPUMemoryUsed;
            Gpu.GPUName = adm.Hardware._gpu.GPUName;
            Gpu.GPUShader = adm.Hardware._gpu.GPUShader;
            Gpu.GPUVEngineLoad = adm.Hardware._gpu.GPUVEngineLoad;
            Hdd.HDName = adm.Hardware._hdd.HDName;
            Hdd.HDTemp = adm.Hardware._hdd.HDTemp;
            Hdd.HDUsedSpace = adm.Hardware._hdd.HDUsedSpace;
            Mb.MBName = adm.Hardware._mb.MBName;
            Memory.Name = adm.Hardware._memory.Name;
            Memory.MemoryLoad = adm.Hardware._memory.MemoryLoad;
            Memory.UsedMemory = adm.Hardware._memory.UsedMemory;
            //config = conf;



        }

    }
}