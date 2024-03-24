#include "animal.h"


void Mamifer::creste_mancare(int _mancare) {
	mancare += _mancare;
}
Mamifer::Mamifer(int _mancare)
{
	mancare = _mancare;
}
Mamifer::Mamifer(double _varsta)
{
	varsta = _varsta;
}

Mamifer::Mamifer(const Forta& _forta)
{
	forta.forta = _forta.forta;
}


void Mamifer::creste_varsta(int _varsta)
{
	varsta += _varsta;
}

void Mamifer::scade_mancare(int _mancare)
{
	mancare -= _mancare;
}
int Mamifer::get_mancare() {
	return mancare;
}

void Mamifer::set_mancare(int _mancare) {
 mancare = _mancare;
}

double Mamifer::get_varsta()
{
	return varsta;
}

void Mamifer::set_varsta(int _varsta)
{
  varsta = _varsta;
}
int Catel::get_sanatate()
{
	return sanatate;
}
void Catel::set_sanatate(int _sanatate)
{
	sanatate = _sanatate;
}

bool Catel::get_e_de_rasa() {
	return e_de_rasa;
}

void Catel::set_e_de_rasa(bool _e_de_rasa) {
	e_de_rasa = _e_de_rasa;
}

string Catel::get_nume_catel() {
	return nume_catel;
}
void Catel::set_nume_catel(string _nume_catel) {
	nume_catel = _nume_catel;
}
int Pisoi::get_sanatate()
{
	return sanatate;
}

void Pisoi::set_sanatate(int _sanatate)
{
	sanatate = _sanatate;
}

bool Pisoi::get_e_de_rasa() {
	return e_de_rasa;
}

void Pisoi::set_e_de_rasa(bool _e_de_rasa) {
	e_de_rasa = _e_de_rasa;
}

string Pisoi::get_nume_pisoi() {
	return nume_pisoi;
}

void Pisoi::set_nume_pisoi(string _nume_catel) {
	nume_pisoi = nume_pisoi;
}
bool pui_Catel::get_e_blanos() {
	return e_blanos;
}
void pui_Catel::set_e_blanos(bool _e_blanos) {
	e_blanos = _e_blanos;
}