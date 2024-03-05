load("lab4=_order1_3.mat")
u=data.u;
y=data.y;
figure;
subplot(2,1,1)
plot(t,u)
subplot(2,1,2)
plot(t,y )

%date grafic
yss=7.5;
y0=yss;
uss=1.5;
ymax=9.08;
K=yss/uss;
yt2=yss+0.368*(ymax-yss);
t2=10.56;
t1=7.44;
T=t2-t1;

fprintf("Factorul de proportionalitate este:  %.2f\n",K)
fprintf("Perioada este :  %.2f\n",T)

[A ,B,C,D ]=tf2ss(K,[T 1]);
fdt=ss(A,B,C,D);

u_val=u(110:end);
y_val=y(110:end);
t_val=t(110:end);

%simulare
x=lsim(fdt,u_val,t_val,y0);
figure;
hold on
plot(t_val,u_val)
plot(t_val,y_val)
plot(t_val,x )
title("Model obtinut")
%MSE
eroare=y_val-x;
N=length(y_val);
MSE=1/N*sum(eroare.^2);
fprintf("Eroarea medie patratica pentru ordinul 1 este:  %.2f\n",MSE)


%% ordin 2
load("lab4_order2_3.mat")
u=data.u;
y=data.y;
figure;
subplot(2,1,1)
plot(t,u)
subplot(2,1,2)
plot(t,y )

%date de pe grafic
yss=0.1;
uss=0.5;
ymax=0.2;
K=yss/uss;
t1=3.86;
t2=8.26;
t3=11.2;
T0=11.6-5.02;
Ts=t2-t1;

fprintf("Factorul de proportionalitate este:  %.2f\n",K)
fprintf("Perioada este :  %.2f\n",T0)

A_pls = Ts*sum(y(t1:t2)- yss);
A_min = Ts*sum(y(t2:t3)-yss);
M= A_min/A_pls;

tita=(log(1/M))/sqrt(pi*pi+log(M)*log(M)); %factor de amortizare
wn=(2*pi)/T0*sqrt(1-tita*tita); %pulsatia naturala

[A,B,C,D] = tf2ss((K*wn*wn),[1, 2*tita*wn, wn*wn]);
fdt = ss(A,B,C,D);

%validare
u_val=u(110:end);
y_val=y(110:end);
t_val=t(110:end);

%simulare
x=lsim(fdt,u_val,t_val,[yss,0]);
figure;
hold on
plot(t_val,u_val)
plot(t_val,y_val)
plot(t_val,x )
title("Model obtinut")

%MSE
eroare=y_val-x;
N=length(y_val);
MSE=1/N*sum(eroare.^2);
fprintf("Eroarea medie patratica pentru ordinul 1 este:  %.5f\n",MSE)


