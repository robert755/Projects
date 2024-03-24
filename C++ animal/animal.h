#pragma once
#include <iostream>
#include <string>
using std::string;

class Animal {

public:

	virtual void creste_varsta(int noua_varsta) = 0;
	virtual void scade_mancare(int _mancare) = 0;
	virtual void creste_mancare(int _mancare) = 0;

};
class Mamifer : public Animal,public Forta{
	friend class Forta;
public:
	friend class Forta;
	Mamifer(int _mancare);
	Mamifer(double _varsta);
	Mamifer(const Forta& _forta);
	virtual void creste_varsta(int noua_varsta) = 0;
	virtual void scade_mancare(int _mancare) = 0;
	virtual void creste_mancare(int _mancare) = 0;
	Forta forta;
	int get_mancare();
	void set_mancare(int _mancare);

	double get_varsta();
	void set_varsta(int _varsta);
private:
	int mancare;
	double varsta;
};

class Forta {
	friend class Mamifer;
	Forta();
public:
	int forta;
};

class Catel : public Mamifer {

public:

	int get_sanatate();
	void set_sanatate(int _sanatate);

	bool get_e_de_rasa();
	void set_e_de_rasa(bool _e_de_rasa);

	string get_nume_catel();
	void set_nume_catel(string _nume_catel);

protected:
	string nume_catel;

private:
	int sanatate;
	bool e_de_rasa;

};
class Pisoi : public Mamifer {

public:

	int get_sanatate();
	void set_sanatate(int _sanatate);

	bool get_e_de_rasa();
	void set_e_de_rasa(bool _e_de_rasa);

	string get_nume_pisoi();
	void set_nume_pisoi(string _nume_catel);

protected:
	string nume_pisoi;

private:
	int sanatate;
	bool e_de_rasa;
};
class pui_Catel : public Catel {

	bool get_e_blanos();
	void set_e_blanos(bool _e_blanos);

private:
	bool e_blanos;

public:
	string culoare;
	int marime;
};