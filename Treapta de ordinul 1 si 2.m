load("lab3_order1_3.mat")
u=data.u;
y=data.y;

%plot initial
figure;
subplot(2,1,1)
plot(t,u)
title("intrarea sistemului de ordin 1")
subplot(2,1,2)
plot(t,y)
title("iesirea sistemului de ordin 1")

%date de pe grafic
uss=3;
yss=9.05;
yzero=0;
uzero=0;
K=(yss-yzero)/(uss-uzero); %factor de prop
yt=yzero+0.632*(yss-yzero); %y(t)
T=2.94;
fprintf("Factorul de proportionalitate este:  %.2f\n",K)
fprintf("Perioada este :  %.2f\n",T)
H=tf(K,[T 1]);
disp(H)

%validare
u_val=u(201:end);
y_val=y(201:end);
t_val=t(201:end);

%simulare
x=lsim(H,u_val,t_val);
figure;
hold on
plot(t_val,u_val)
plot(t_val,y_val)
plot(t_val,x )
title("Model obtinut ordin 1")

%MSE
eroare=y_val-x;
N=length(y_val);
MSE=1/N*sum(eroare.^2);
fprintf("Eroarea medie patratica pentru ordinul 1 este:  %.2f\n",MSE)



%% ordin 2

load("lab3_order2_3.mat")
u=data.u;
y=data.y;

%plot initial 
figure;
subplot(2,1,1)
plot(t,u)
title("intrarea sistemului ordin 2")
subplot(2,1,2)
plot(t,y)
title("iesirea sistemului ordin 2")

uss=2;
yss=6.02;
K=yss/uss; %factorul de proportionalitate
t1=3.5; %primul maxim 
yt1=9.08; % y primului maxim y(t1)
t2=10.15; %al doilea maxim
yzero=0;
M=(yt1-yss)/(yss-yzero); %suprareglaj
tita=(log(1/M))/sqrt(pi*pi+log(M)*log(M)); %factor de amortizare
T=t2-t1; %perioada
wn=(2*pi)/T*sqrt(1-tita*tita); %pulsatia naturala

fprintf("Factorul de amortizare:  %.2f\n",tita)
fprintf("Suprareglajul este :  %.2f\n",M)
fprintf("Factorul de proportionalitate este:  %.2f\n",K)
fprintf("Perioada este:  %.2f\n",T)


H=tf((K*wn*wn),[1, 2*tita*wn, wn*wn]);
disp(H)

%datele de validare
u_val=u(201:end);
y_val=y(201:end);
t_val=t(201:end);

x=lsim(H,u_val,t_val);
figure;
hold on
plot(t_val,u_val)
plot(t_val,y_val)
plot(t_val,x)
title("Model obtinut")

%MSE ordin 2
eroare=y_val-x;
N=length(y_val);
MSE=1/N*sum(eroare.^2);
fprintf("EROAREA MEDIE PATRATICA  PENTRU ORDINUL 2 ESTE :  %.2f\n",MSE)








