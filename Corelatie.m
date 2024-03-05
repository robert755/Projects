load("lab5_3.mat")
%plot pentru validare
figure;
plot(val)
title("Datele de validare");

%identificarea eliminand valorile medii
detr=detrend(id,0);
figure;
plot(detr)
title("Datele de identificare de medie 0")

%date 
u=detr.u;
y=detr.y;
u_val=val.u;
y_val=val.y;

%zgomot alb
figure;
[thau,c]=xcorr(u);
plot(thau,c)
title("Autocorelatie zgomot alb")
%lungimi 
N=length(u);
Z=length(y_val);

%functiile ru si ryu dupa curs
ru=[];
ryu=[];

for thau=1:N
    x=0;
    for k=1:(N-thau)
        x=x+(u(k+thau-1)*u(k));
    end
    ru(thau)=x*1/N;
end

for thau=1:N
    z=0;
    for k=1:(N-thau) 
       z=z+(y(k+thau-1)*u(k));
      end 
    ryu(thau)=z*1/N;
end

%FIR UL M 
for M=150
 for i = 1:N
  for j = 1:M
    if(i==j)
      RU(i,j)=ru(1);
      elseif (i-j+1 >= 1)&&(i-j+1<=N)
    RU(i,j)=ru(i-j+1);
   end
 end
end
%convolutiile 
H=RU\ryu';
y_hat1=conv(H,u);
y_hat1=y_hat1(1:length(u));

y_hat2=conv(H,u_val);
y_hat2=y_hat2(1:length(u_val));

%eroare id
eroare=y-y_hat1;
MSE1=1/N*sum(eroare.^2);
%eroare val
eroare2=y_val-y_hat2;
MSE2=1/Z*sum(eroare2.^2);
end

%plotari 
figure;
plot(y_hat1)
hold on;
plot(y), 
title("Identificarea vs date initiale");

figure;
plot(y_hat2)
hold on;
plot(y_val), 
title("Validarea vs date initiale");
 
fprintf("EROAREA MEDIE PATRATICA 1 ESTE :  %.2f\n",MSE1)
fprintf("EROAREA MEDIE PATRATICA 2 ESTE :  %.2f\n",MSE2)



