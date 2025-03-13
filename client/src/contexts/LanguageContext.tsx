import {
  createContext,
  ReactNode,
  useContext,
  useEffect,
  useState,
} from "react";

export type Language = "hu" | "en";

export interface TranslationDict {
  [key: string]: string;
}

interface LanguageContextType {
  language: Language;
  setLanguage: (language: Language) => void;
  t: (key: string, namespace?: string) => string;
  loadNamespace: (namespace: string) => Promise<void>;
  loadedNamespaces: string[];
}

const LanguageContext = createContext<LanguageContextType | undefined>(
  undefined
);

interface LanguageProviderProps {
  children: ReactNode;
  defaultNamespaces?: string[];
}

export const LanguageProvider: React.FC<LanguageProviderProps> = ({
  children,
  defaultNamespaces = ["common"],
}) => {
  const [language, setLanguage] = useState<Language>(() => {
    const savedLanguage = localStorage.getItem("language");
    return (savedLanguage as Language) || "hu";
  });

  const [translations, setTranslations] = useState<
    Record<string, TranslationDict>
  >({});
  const [loadedNamespaces, setLoadedNamespaces] = useState<string[]>([]);

  useEffect(() => {
    localStorage.setItem("language", language);
  }, [language]);

  const loadNamespace = async (namespace: string): Promise<void> => {
    if (loadedNamespaces.includes(namespace)) {
      return;
    }

    try {
      const module = await import(
        `../components/translations/${namespace}/${language}.ts`
      );
      setTranslations((prev) => ({
        ...prev,
        [namespace]: module.default,
      }));

      setLoadedNamespaces((prev) => [...prev, namespace]);
    } catch (error) {
      console.error(
        `Failed to load translations for namespace: ${namespace}`,
        error
      );
    }
  };

  useEffect(() => {
    const loadDefaultNamespaces = async () => {
      setLoadedNamespaces([]);
      setTranslations({});

      for (const namespace of defaultNamespaces) {
        await loadNamespace(namespace);
      }
    };

    loadDefaultNamespaces();
  }, [language]);

  const t = (key: string, namespace = "common"): string => {
    if (!loadedNamespaces.includes(namespace)) {
      return key;
    }

    return translations[namespace]?.[key] || key;
  };

  return (
    <LanguageContext.Provider
      value={{ language, setLanguage, t, loadNamespace, loadedNamespaces }}
    >
      {children}
    </LanguageContext.Provider>
  );
};

export const useLanguage = (): LanguageContextType => {
  const context = useContext(LanguageContext);
  if (context === undefined) {
    throw new Error("useLanguage must be used within a LanguageProvider");
  }
  return context;
};
