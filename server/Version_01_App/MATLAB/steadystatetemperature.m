function[Tss]=steadystatetemperature(L,Ac,PM,CPM)

%   Greg Nellis, 10-10-07
%   [Tss]=steadystatetemperature(L,Ac,PM,CPM)
%   
%   This function returns the ultimate, steady-state operating temperature
%   associated with a single cryocooler interacting with a single strut
%
%   Inputs
%   L - length of the strut (m)
%   Ac - cross-sectional area of the strut (m^2)
%   PM - property matrix for the strut material
%       1st column of PM should be the temperature of a property data
%       point (K)
%       2nd column of PM should be the thermal conductivity at the
%       corresponding data point (W/m-K)
%   CPM - cooling power matrix for the cryocooler
%       1st column of CPM should be the temperature of a point on the cooling power
%       curve (K)
%       2nd column of CPM should be the cooling power at the corresponding
%       data point (W)
%
%   Outputs
%   Tss - steady-state operating temperature (K)
%
%   Note - 
%   1. the first row of CPM should be the lowest operating temperature of
%   the cooler - the cooling power associated with the last row of CPM
%   should be zero
%   2. the first row of PM should be the lowest temperature data point for
%   the properties - the temperature associated with the first row of PM
%   should be less than the temperature associated with the first row of CPM

[Npm,g]=size(PM);       %size of property matrix
[Ncpm,g]=size(CPM);     %size of cooling power matrix
T_H=300;                %the hot end of the strut is assumed to be at 300 K
T_low=CPM(1,1);         %the lowest possible steady-state operating temperature is the lowest data point in the cooling curve matrix

N_try=10;               %number of steady-state temperatures to try
T_try=linspace(T_low,T_H-0.01,N_try)';   
                        %vector of steady state temperatures to try
N_int=2*Npm;            %number of data points for integration of conductivity, should not be much different from Ncpm
for i=1:N_try
    T_i=linspace(T_try(i),T_H,N_int);    %vector of temperatures to interpolate for integration
    k_i=interp1(PM(:,1),PM(:,2),T_i);    %interpolated conductivities for integrration
    q(i,1)=trapz(T_i,k_i)*Ac/L;          %heat load
end
q_load=interp1(CPM(:,1),CPM(:,2),T_try);    %cooling power at T_try
q_net=q-q_load;                             %net cooling power - this must be zero at steady state
Tss=interp1(q_net,T_try,0);                 %get steady state operating temperature


