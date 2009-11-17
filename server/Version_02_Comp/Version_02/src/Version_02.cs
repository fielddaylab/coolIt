/*
* MATLAB Compiler: 4.7 (R2007b)
* Date: Mon Nov 26 18:52:55 2007
* Arguments: "-B" "macro_default" "-W" "dotnet:Version_02,Version_02,0.0,private" "-d"
* "C:\Users\mike\Documents\Visual Studio
* 2005\Projects\CoolIt\Version_02_Comp\Version_02\src" "-T" "link:lib" "-v"
* "class{Version_02:C:\Users\mike\Documents\Visual Studio
* 2005\Projects\CoolIt\Version_02_App\MATLAB\steadystatetemperature.m}" 
*/

using System;
using System.Reflection;

using MathWorks.MATLAB.NET.Arrays;
using MathWorks.MATLAB.NET.Utility;


[assembly: System.Reflection.AssemblyVersion("0.0.*")]
#if SHARED
[assembly: System.Reflection.AssemblyKeyFile(@"")]
#endif

namespace Version_02
{
  /// <summary>
  /// The Version_02 class provides a CLS compliant interface to the M-functions
  /// contained in the files:
  /// <newpara></newpara>
  /// C:\Users\mike\Documents\Visual Studio
  /// 2005\Projects\CoolIt\Version_02_App\MATLAB\steadystatetemperature.m
  /// <newpara></newpara>
  /// deployprint.m
  /// <newpara></newpara>
  /// printdlg.m
  /// </summary>
  /// <remarks>
  /// @Version 0.0
  /// </remarks>
  public class Version_02 : IDisposable
    {
      #region Constructors

      /// <summary internal= "true">
      /// The static constructor instantiates and initializes the MATLAB Component
      /// Runtime instance.
      /// </summary>
      static Version_02()
        {
          if (MWArray.MCRAppInitialized)
            {
              Assembly assembly= Assembly.GetExecutingAssembly();

              string ctfFilePath= assembly.Location;

              int lastDelimeter= ctfFilePath.LastIndexOf(@"\");

              ctfFilePath= ctfFilePath.Remove(lastDelimeter, (ctfFilePath.Length - lastDelimeter));

              mcr= new MWMCR(MCRComponentState.MCC_Version_02_name_data,
                             MCRComponentState.MCC_Version_02_root_data,
                             MCRComponentState.MCC_Version_02_public_data,
                             MCRComponentState.MCC_Version_02_session_data,
                             MCRComponentState.MCC_Version_02_matlabpath_data,
                             MCRComponentState.MCC_Version_02_classpath_data,
                             MCRComponentState.MCC_Version_02_libpath_data,
                             MCRComponentState.MCC_Version_02_mcr_application_options,
                             MCRComponentState.MCC_Version_02_mcr_runtime_options,
                             MCRComponentState.MCC_Version_02_mcr_pref_dir,
                             MCRComponentState.MCC_Version_02_set_warning_state,
                             ctfFilePath, true);
            }
          else
            {
              throw new ApplicationException("MWArray assembly could not be initialized");
            }
        }


      /// <summary>
      /// Constructs a new instance of the Version_02 class.
      /// </summary>
      public Version_02()
        {
        }


      #endregion Constructors

      #region Finalize

      /// <summary internal= "true">
      /// Class destructor called by the CLR garbage collector.
      /// </summary>
      ~Version_02()
        {
          Dispose(false);
        }


      /// <summary>
      /// Frees the native resources associated with this object
      /// </summary>
      public void Dispose()
        {
          Dispose(true);

          GC.SuppressFinalize(this);
        }


      /// <summary internal= "true">
      /// Internal dispose function
      /// </summary>
      protected virtual void Dispose(bool disposing)
        {
          if (!disposed)
            {
              disposed= true;

              if (disposing)
                {
                  // Free managed resources;
                }

              // Free native resources
            }
        }


      #endregion Finalize

      #region Methods

      /// <summary>
      /// Provides a single output, 0-input interface to the steadystatetemperature
      /// M-function.
      /// </summary>
      /// <remarks>
      /// M-Documentation:
      /// Greg Nellis, 10-10-07
      /// [Tss]=steadystatetemperature(L,Ac,PM,CPM)
      /// This function returns the ultimate, steady-state operating temperature
      /// associated with a single cryocooler interacting with a single strut
      /// Inputs
      /// L - length of the strut (m)
      /// Ac - cross-sectional area of the strut (m^2)
      /// PM - property matrix for the strut material
      /// 1st column of PM should be the temperature of a property data
      /// point (K)
      /// 2nd column of PM should be the thermal conductivity at the
      /// corresponding data point (W/m-K)
      /// CPM - cooling power matrix for the cryocooler
      /// 1st column of CPM should be the temperature of a point on the cooling power
      /// curve (K)
      /// 2nd column of CPM should be the cooling power at the corresponding
      /// data point (W)
      /// Outputs
      /// Tss - steady-state operating temperature (K)
      /// Note - 
      /// 1. the first row of CPM should be the lowest operating temperature of
      /// the cooler - the cooling power associated with the last row of CPM
      /// should be zero
      /// 2. the first row of PM should be the lowest temperature data point for
      /// the properties - the temperature associated with the first row of PM
      /// should be less than the temperature associated with the first row of CPM
      /// </remarks>
      /// <returns>An MWArray containing the first output argument.</returns>
      ///
      public MWArray steadystatetemperature()
        {
          return mcr.EvaluateFunction("steadystatetemperature");
        }


      /// <summary>
      /// Provides a single output, 1-input interface to the steadystatetemperature
      /// M-function.
      /// </summary>
      /// <remarks>
      /// M-Documentation:
      /// Greg Nellis, 10-10-07
      /// [Tss]=steadystatetemperature(L,Ac,PM,CPM)
      /// This function returns the ultimate, steady-state operating temperature
      /// associated with a single cryocooler interacting with a single strut
      /// Inputs
      /// L - length of the strut (m)
      /// Ac - cross-sectional area of the strut (m^2)
      /// PM - property matrix for the strut material
      /// 1st column of PM should be the temperature of a property data
      /// point (K)
      /// 2nd column of PM should be the thermal conductivity at the
      /// corresponding data point (W/m-K)
      /// CPM - cooling power matrix for the cryocooler
      /// 1st column of CPM should be the temperature of a point on the cooling power
      /// curve (K)
      /// 2nd column of CPM should be the cooling power at the corresponding
      /// data point (W)
      /// Outputs
      /// Tss - steady-state operating temperature (K)
      /// Note - 
      /// 1. the first row of CPM should be the lowest operating temperature of
      /// the cooler - the cooling power associated with the last row of CPM
      /// should be zero
      /// 2. the first row of PM should be the lowest temperature data point for
      /// the properties - the temperature associated with the first row of PM
      /// should be less than the temperature associated with the first row of CPM
      /// </remarks>
      /// <param name="L">Input argument #1</param>
      /// <returns>An MWArray containing the first output argument.</returns>
      ///
      public MWArray steadystatetemperature(MWArray L)
        {
          return mcr.EvaluateFunction("steadystatetemperature", L);
        }


      /// <summary>
      /// Provides a single output, 2-input interface to the steadystatetemperature
      /// M-function.
      /// </summary>
      /// <remarks>
      /// M-Documentation:
      /// Greg Nellis, 10-10-07
      /// [Tss]=steadystatetemperature(L,Ac,PM,CPM)
      /// This function returns the ultimate, steady-state operating temperature
      /// associated with a single cryocooler interacting with a single strut
      /// Inputs
      /// L - length of the strut (m)
      /// Ac - cross-sectional area of the strut (m^2)
      /// PM - property matrix for the strut material
      /// 1st column of PM should be the temperature of a property data
      /// point (K)
      /// 2nd column of PM should be the thermal conductivity at the
      /// corresponding data point (W/m-K)
      /// CPM - cooling power matrix for the cryocooler
      /// 1st column of CPM should be the temperature of a point on the cooling power
      /// curve (K)
      /// 2nd column of CPM should be the cooling power at the corresponding
      /// data point (W)
      /// Outputs
      /// Tss - steady-state operating temperature (K)
      /// Note - 
      /// 1. the first row of CPM should be the lowest operating temperature of
      /// the cooler - the cooling power associated with the last row of CPM
      /// should be zero
      /// 2. the first row of PM should be the lowest temperature data point for
      /// the properties - the temperature associated with the first row of PM
      /// should be less than the temperature associated with the first row of CPM
      /// </remarks>
      /// <param name="L">Input argument #1</param>
      /// <param name="Ac">Input argument #2</param>
      /// <returns>An MWArray containing the first output argument.</returns>
      ///
      public MWArray steadystatetemperature(MWArray L, MWArray Ac)
        {
          return mcr.EvaluateFunction("steadystatetemperature", L, Ac);
        }


      /// <summary>
      /// Provides a single output, 3-input interface to the steadystatetemperature
      /// M-function.
      /// </summary>
      /// <remarks>
      /// M-Documentation:
      /// Greg Nellis, 10-10-07
      /// [Tss]=steadystatetemperature(L,Ac,PM,CPM)
      /// This function returns the ultimate, steady-state operating temperature
      /// associated with a single cryocooler interacting with a single strut
      /// Inputs
      /// L - length of the strut (m)
      /// Ac - cross-sectional area of the strut (m^2)
      /// PM - property matrix for the strut material
      /// 1st column of PM should be the temperature of a property data
      /// point (K)
      /// 2nd column of PM should be the thermal conductivity at the
      /// corresponding data point (W/m-K)
      /// CPM - cooling power matrix for the cryocooler
      /// 1st column of CPM should be the temperature of a point on the cooling power
      /// curve (K)
      /// 2nd column of CPM should be the cooling power at the corresponding
      /// data point (W)
      /// Outputs
      /// Tss - steady-state operating temperature (K)
      /// Note - 
      /// 1. the first row of CPM should be the lowest operating temperature of
      /// the cooler - the cooling power associated with the last row of CPM
      /// should be zero
      /// 2. the first row of PM should be the lowest temperature data point for
      /// the properties - the temperature associated with the first row of PM
      /// should be less than the temperature associated with the first row of CPM
      /// </remarks>
      /// <param name="L">Input argument #1</param>
      /// <param name="Ac">Input argument #2</param>
      /// <param name="PM">Input argument #3</param>
      /// <returns>An MWArray containing the first output argument.</returns>
      ///
      public MWArray steadystatetemperature(MWArray L, MWArray Ac, MWArray PM)
        {
          return mcr.EvaluateFunction("steadystatetemperature", L, Ac, PM);
        }


      /// <summary>
      /// Provides a single output, 4-input interface to the steadystatetemperature
      /// M-function.
      /// </summary>
      /// <remarks>
      /// M-Documentation:
      /// Greg Nellis, 10-10-07
      /// [Tss]=steadystatetemperature(L,Ac,PM,CPM)
      /// This function returns the ultimate, steady-state operating temperature
      /// associated with a single cryocooler interacting with a single strut
      /// Inputs
      /// L - length of the strut (m)
      /// Ac - cross-sectional area of the strut (m^2)
      /// PM - property matrix for the strut material
      /// 1st column of PM should be the temperature of a property data
      /// point (K)
      /// 2nd column of PM should be the thermal conductivity at the
      /// corresponding data point (W/m-K)
      /// CPM - cooling power matrix for the cryocooler
      /// 1st column of CPM should be the temperature of a point on the cooling power
      /// curve (K)
      /// 2nd column of CPM should be the cooling power at the corresponding
      /// data point (W)
      /// Outputs
      /// Tss - steady-state operating temperature (K)
      /// Note - 
      /// 1. the first row of CPM should be the lowest operating temperature of
      /// the cooler - the cooling power associated with the last row of CPM
      /// should be zero
      /// 2. the first row of PM should be the lowest temperature data point for
      /// the properties - the temperature associated with the first row of PM
      /// should be less than the temperature associated with the first row of CPM
      /// </remarks>
      /// <param name="L">Input argument #1</param>
      /// <param name="Ac">Input argument #2</param>
      /// <param name="PM">Input argument #3</param>
      /// <param name="CPM">Input argument #4</param>
      /// <returns>An MWArray containing the first output argument.</returns>
      ///
      public MWArray steadystatetemperature(MWArray L, MWArray Ac,
                                            MWArray PM, MWArray CPM)
        {
          return mcr.EvaluateFunction("steadystatetemperature", L, Ac, PM, CPM);
        }


      /// <summary>
      /// Provides the standard 0-input interface to the steadystatetemperature
      /// M-function.
      /// </summary>
      /// <remarks>
      /// M-Documentation:
      /// Greg Nellis, 10-10-07
      /// [Tss]=steadystatetemperature(L,Ac,PM,CPM)
      /// This function returns the ultimate, steady-state operating temperature
      /// associated with a single cryocooler interacting with a single strut
      /// Inputs
      /// L - length of the strut (m)
      /// Ac - cross-sectional area of the strut (m^2)
      /// PM - property matrix for the strut material
      /// 1st column of PM should be the temperature of a property data
      /// point (K)
      /// 2nd column of PM should be the thermal conductivity at the
      /// corresponding data point (W/m-K)
      /// CPM - cooling power matrix for the cryocooler
      /// 1st column of CPM should be the temperature of a point on the cooling power
      /// curve (K)
      /// 2nd column of CPM should be the cooling power at the corresponding
      /// data point (W)
      /// Outputs
      /// Tss - steady-state operating temperature (K)
      /// Note - 
      /// 1. the first row of CPM should be the lowest operating temperature of
      /// the cooler - the cooling power associated with the last row of CPM
      /// should be zero
      /// 2. the first row of PM should be the lowest temperature data point for
      /// the properties - the temperature associated with the first row of PM
      /// should be less than the temperature associated with the first row of CPM
      /// </remarks>
      /// <param name="numArgsOut">The number of output arguments to return.</param>
      /// <returns>An Array of length "numArgsOut" containing the output
      /// arguments.</returns>
      ///
      public MWArray[] steadystatetemperature(int numArgsOut)
        {
          return mcr.EvaluateFunction(numArgsOut, "steadystatetemperature");
        }


      /// <summary>
      /// Provides the standard 1-input interface to the steadystatetemperature
      /// M-function.
      /// </summary>
      /// <remarks>
      /// M-Documentation:
      /// Greg Nellis, 10-10-07
      /// [Tss]=steadystatetemperature(L,Ac,PM,CPM)
      /// This function returns the ultimate, steady-state operating temperature
      /// associated with a single cryocooler interacting with a single strut
      /// Inputs
      /// L - length of the strut (m)
      /// Ac - cross-sectional area of the strut (m^2)
      /// PM - property matrix for the strut material
      /// 1st column of PM should be the temperature of a property data
      /// point (K)
      /// 2nd column of PM should be the thermal conductivity at the
      /// corresponding data point (W/m-K)
      /// CPM - cooling power matrix for the cryocooler
      /// 1st column of CPM should be the temperature of a point on the cooling power
      /// curve (K)
      /// 2nd column of CPM should be the cooling power at the corresponding
      /// data point (W)
      /// Outputs
      /// Tss - steady-state operating temperature (K)
      /// Note - 
      /// 1. the first row of CPM should be the lowest operating temperature of
      /// the cooler - the cooling power associated with the last row of CPM
      /// should be zero
      /// 2. the first row of PM should be the lowest temperature data point for
      /// the properties - the temperature associated with the first row of PM
      /// should be less than the temperature associated with the first row of CPM
      /// </remarks>
      /// <param name="numArgsOut">The number of output arguments to return.</param>
      /// <param name="L">Input argument #1</param>
      /// <returns>An Array of length "numArgsOut" containing the output
      /// arguments.</returns>
      ///
      public MWArray[] steadystatetemperature(int numArgsOut, MWArray L)
        {
          return mcr.EvaluateFunction(numArgsOut, "steadystatetemperature", L);
        }


      /// <summary>
      /// Provides the standard 2-input interface to the steadystatetemperature
      /// M-function.
      /// </summary>
      /// <remarks>
      /// M-Documentation:
      /// Greg Nellis, 10-10-07
      /// [Tss]=steadystatetemperature(L,Ac,PM,CPM)
      /// This function returns the ultimate, steady-state operating temperature
      /// associated with a single cryocooler interacting with a single strut
      /// Inputs
      /// L - length of the strut (m)
      /// Ac - cross-sectional area of the strut (m^2)
      /// PM - property matrix for the strut material
      /// 1st column of PM should be the temperature of a property data
      /// point (K)
      /// 2nd column of PM should be the thermal conductivity at the
      /// corresponding data point (W/m-K)
      /// CPM - cooling power matrix for the cryocooler
      /// 1st column of CPM should be the temperature of a point on the cooling power
      /// curve (K)
      /// 2nd column of CPM should be the cooling power at the corresponding
      /// data point (W)
      /// Outputs
      /// Tss - steady-state operating temperature (K)
      /// Note - 
      /// 1. the first row of CPM should be the lowest operating temperature of
      /// the cooler - the cooling power associated with the last row of CPM
      /// should be zero
      /// 2. the first row of PM should be the lowest temperature data point for
      /// the properties - the temperature associated with the first row of PM
      /// should be less than the temperature associated with the first row of CPM
      /// </remarks>
      /// <param name="numArgsOut">The number of output arguments to return.</param>
      /// <param name="L">Input argument #1</param>
      /// <param name="Ac">Input argument #2</param>
      /// <returns>An Array of length "numArgsOut" containing the output
      /// arguments.</returns>
      ///
      public MWArray[] steadystatetemperature(int numArgsOut,
                                              MWArray L, MWArray Ac)
        {
          return mcr.EvaluateFunction(numArgsOut,
                                      "steadystatetemperature", L, Ac);
        }


      /// <summary>
      /// Provides the standard 3-input interface to the steadystatetemperature
      /// M-function.
      /// </summary>
      /// <remarks>
      /// M-Documentation:
      /// Greg Nellis, 10-10-07
      /// [Tss]=steadystatetemperature(L,Ac,PM,CPM)
      /// This function returns the ultimate, steady-state operating temperature
      /// associated with a single cryocooler interacting with a single strut
      /// Inputs
      /// L - length of the strut (m)
      /// Ac - cross-sectional area of the strut (m^2)
      /// PM - property matrix for the strut material
      /// 1st column of PM should be the temperature of a property data
      /// point (K)
      /// 2nd column of PM should be the thermal conductivity at the
      /// corresponding data point (W/m-K)
      /// CPM - cooling power matrix for the cryocooler
      /// 1st column of CPM should be the temperature of a point on the cooling power
      /// curve (K)
      /// 2nd column of CPM should be the cooling power at the corresponding
      /// data point (W)
      /// Outputs
      /// Tss - steady-state operating temperature (K)
      /// Note - 
      /// 1. the first row of CPM should be the lowest operating temperature of
      /// the cooler - the cooling power associated with the last row of CPM
      /// should be zero
      /// 2. the first row of PM should be the lowest temperature data point for
      /// the properties - the temperature associated with the first row of PM
      /// should be less than the temperature associated with the first row of CPM
      /// </remarks>
      /// <param name="numArgsOut">The number of output arguments to return.</param>
      /// <param name="L">Input argument #1</param>
      /// <param name="Ac">Input argument #2</param>
      /// <param name="PM">Input argument #3</param>
      /// <returns>An Array of length "numArgsOut" containing the output
      /// arguments.</returns>
      ///
      public MWArray[] steadystatetemperature(int numArgsOut, MWArray L,
                                              MWArray Ac, MWArray PM)
        {
          return mcr.EvaluateFunction(numArgsOut, "steadystatetemperature",
                                      L, Ac, PM);
        }


      /// <summary>
      /// Provides the standard 4-input interface to the steadystatetemperature
      /// M-function.
      /// </summary>
      /// <remarks>
      /// M-Documentation:
      /// Greg Nellis, 10-10-07
      /// [Tss]=steadystatetemperature(L,Ac,PM,CPM)
      /// This function returns the ultimate, steady-state operating temperature
      /// associated with a single cryocooler interacting with a single strut
      /// Inputs
      /// L - length of the strut (m)
      /// Ac - cross-sectional area of the strut (m^2)
      /// PM - property matrix for the strut material
      /// 1st column of PM should be the temperature of a property data
      /// point (K)
      /// 2nd column of PM should be the thermal conductivity at the
      /// corresponding data point (W/m-K)
      /// CPM - cooling power matrix for the cryocooler
      /// 1st column of CPM should be the temperature of a point on the cooling power
      /// curve (K)
      /// 2nd column of CPM should be the cooling power at the corresponding
      /// data point (W)
      /// Outputs
      /// Tss - steady-state operating temperature (K)
      /// Note - 
      /// 1. the first row of CPM should be the lowest operating temperature of
      /// the cooler - the cooling power associated with the last row of CPM
      /// should be zero
      /// 2. the first row of PM should be the lowest temperature data point for
      /// the properties - the temperature associated with the first row of PM
      /// should be less than the temperature associated with the first row of CPM
      /// </remarks>
      /// <param name="numArgsOut">The number of output arguments to return.</param>
      /// <param name="L">Input argument #1</param>
      /// <param name="Ac">Input argument #2</param>
      /// <param name="PM">Input argument #3</param>
      /// <param name="CPM">Input argument #4</param>
      /// <returns>An Array of length "numArgsOut" containing the output
      /// arguments.</returns>
      ///
      public MWArray[] steadystatetemperature(int numArgsOut,
                                              MWArray L, MWArray Ac,
                                              MWArray PM, MWArray CPM)
        {
          return mcr.EvaluateFunction(numArgsOut, "steadystatetemperature",
                                      L, Ac, PM, CPM);
        }


      /// <summary>
      /// Provides an interface for the steadystatetemperature function in which the
      /// input and output
      /// arguments are specified as an array of MWArrays.
      /// </summary>
      /// <remarks>
      /// This method will allocate and return by reference the output argument
      /// array.<newpara></newpara>
      /// M-Documentation:
      /// Greg Nellis, 10-10-07
      /// [Tss]=steadystatetemperature(L,Ac,PM,CPM)
      /// This function returns the ultimate, steady-state operating temperature
      /// associated with a single cryocooler interacting with a single strut
      /// Inputs
      /// L - length of the strut (m)
      /// Ac - cross-sectional area of the strut (m^2)
      /// PM - property matrix for the strut material
      /// 1st column of PM should be the temperature of a property data
      /// point (K)
      /// 2nd column of PM should be the thermal conductivity at the
      /// corresponding data point (W/m-K)
      /// CPM - cooling power matrix for the cryocooler
      /// 1st column of CPM should be the temperature of a point on the cooling power
      /// curve (K)
      /// 2nd column of CPM should be the cooling power at the corresponding
      /// data point (W)
      /// Outputs
      /// Tss - steady-state operating temperature (K)
      /// Note - 
      /// 1. the first row of CPM should be the lowest operating temperature of
      /// the cooler - the cooling power associated with the last row of CPM
      /// should be zero
      /// 2. the first row of PM should be the lowest temperature data point for
      /// the properties - the temperature associated with the first row of PM
      /// should be less than the temperature associated with the first row of CPM
      /// </remarks>
      /// <param name="numArgsOut">The number of output arguments to return</param>
      /// <param name= "argsOut">Array of MWArray output arguments</param>
      /// <param name= "argsIn">Array of MWArray input arguments</param>
      ///
      public void steadystatetemperature(int numArgsOut, ref MWArray[] argsOut,
                                   MWArray[] argsIn)
        {
          mcr.EvaluateFunction("steadystatetemperature", numArgsOut, ref argsOut, argsIn);
        }


      /// <summary>
      /// This method will cause a MATLAB figure window to behave as a modal dialog box.
      /// The method will not return until all the figure windows associated with this
      /// component have been closed.
      /// </summary>
      /// <remarks>
      /// An application should only call this method when required to keep the
      /// MATLAB figure window from disappearing.  Other techniques, such as calling
      /// Console.ReadLine() from the application should be considered where
      /// possible.</remarks>
      ///
      public void WaitForFiguresToDie()
        {
          mcr.WaitForFiguresToDie();
        }


      
      #endregion Methods

      #region Class Members

      private static MWMCR mcr= null;

      private bool disposed= false;

      #endregion Class Members
    }
}
