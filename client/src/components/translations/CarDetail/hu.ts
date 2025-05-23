import { CarCondition } from "../../enums/Car";

const translations = {
  properties: "Tulajdonságai",
  carBrand: "Márka",
  carModel: "Modell",
  condition: "Állapot",
  year: "Évjárat",
  carType: "Autó típusa",
  fuelType: "Üzemanyag típusa",
  transmissionType: "Sebességváltó típusa",
  seats: "Ülések száma",
  doors: "Ajtók száma",
  regNumber: "Rendszám",
  description: "Leírás",
  pricePerHour: "Ár / óra",
  pricePerDay: "Ár / nap",
  purchase: "Bérlés",
  [CarCondition.NEW]: "új",
  [CarCondition.EXCELLENT]: "kiváló",
  [CarCondition.GOOD]: "jó",
  [CarCondition.FAIR]: "megfelelő",
  [CarCondition.POOR]: "gyenge",
  sedan: "szedán",
  suv: "SUV",
  hatchback: "ferdehátú",
  convertible: "kabrió",
  coupe: "kupé",
  wagon: "kombi",
  pickup: "platós",
  minivan: "minibusz",
  petrol: "benzin",
  diesel: "dízel",
  electric: "elektromos",
  hybrid: "hibrid",
  gas: "gáz",
  automatic: "automata",
  manual: "manuális",
  "semi-automatic": "félautomata",
  CVT: "fokozatmentes",
  purchaseSuccess: "Sikeres vásárlás!",
  paypalError: "Hiba történt vásárlás közben.",
  reviews: "Vélemények",
  loginRequired: "Bejelentkezés szükséges a vélemény íráshoz!",
  writeReview: "Írd meg te is a véleményed!",
  send: "Küldés",
  sending: "Küldés...",
  commentSubmitted: "A véleményed elküldve!",
  errorSubmittingComment:
    "Hiba történt a vélemény küldésekor. Kérjük, próbáld újra.",
  errorFetchingCar: "Hiba az autó adatainak betöltésekor",
  commentRequired: "Kérjük, írj véleményt küldés előtt",
  noReviews: "Még nincsenek vélemények. Legyél te az első!",
  comfort: "Kényelem",
  performance: "Teljesítmény",
  fuel_efficiency: "Üzemanyag-hatékonyság",
  safety: "Biztonság",
  value_for_money: "Ár-érték arány",
  signIn: "Be kell jelentkezned, hogy kibéreld ezt a járművet!",
  rented: "Ez a jármű már ki van bérelve!",
  purchaseError:
    "Hiba történt vásárlás közben. Frissítsd az oldalt, és próbáld újra",
  availableUntil: "Elérhető eddig",
  cantRentOwn: "Nem tudod kibérelni a saját autódat.",
  successfullyPurchased: "sikeresen kibérelve a következő napokra:",
  rentFailed: "<b>Bérlés sikertelen.</b> A következő hiba történt:",
  basePrice: "Alap ár",
};

export default translations;
