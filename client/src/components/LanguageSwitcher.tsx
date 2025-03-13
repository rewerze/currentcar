import React from "react";
import { useLanguage } from "../contexts/LanguageContext";

const LanguageSwitcher: React.FC = () => {
  const { language, setLanguage } = useLanguage();

  const toggleLanguage = () => {
    setLanguage(language === "hu" ? "en" : "hu");
  };

  return (
    <button
      className="btn text-light"
      type="button"
      id="lang"
      onClick={toggleLanguage}
    >
      {language === "hu" ? "HU" : "EN"}
    </button>
  );
};

export default LanguageSwitcher;
