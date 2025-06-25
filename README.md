# Car Rental App

## Opis projektu

Car Rental App to desktopowa aplikacja okienkowa napisana w technologii WPF (.NET C#) według wzorca architektonicznego Model-View-ViewModel (MVVM). Umożliwia zarządzanie flotą samochodów, klientami oraz procesem wypożyczeń.

## Funkcjonalności

* Logowanie i autoryzacja użytkowników (role: Administrator, Pracownik)
* Zarządzanie samochodami (dodawanie, edycja, usuwanie)
* Zarządzanie klientami (dodawanie, edycja, usuwanie)
* Obsługa procesu wypożyczeń: wybór auta, klienta, dat, obliczanie ceny
* Historia wypożyczeń i przegląd statusów
* Walidacja danych oraz komunikaty o błędach

## Technologie

* .NET 6+ / .NET Framework (zgodnie z konfiguracją projektu)
* WPF (Windows Presentation Foundation)
* C#
* MVVM (Model-View-ViewModel)
* ADO.NET lub Entity Framework (warstwa dostępu do danych)
* SQLite (relacyjna baza danych)

## Struktura projektu

Car_Rental_App/  
├── Car_Rental_App.sln  
├── Car_Rental_App/  
│   ├── Models/  
│   │   ├── CarModel.cs  
│   │   ├── CustomerModel.cs  
│   │   ├── DamageModel.cs  
│   │   ├── Enums.cs  
│   │   ├── ReservationModel.cs  
│   │   ├── ServiceModel.cs  
│   │   ├── UserAccountModel.cs  
│   │   ├── UserModel.cs  
│   │   └── UserSessionModel.cs  
│   ├── ViewModels/  
│   │   ├── AddUserViewModel.cs  
│   │   ├── Car_List_ViewModel.cs  
│   │   ├── CustomerManagementViewModel.cs  
│   │   ├── FleetManagementViewModel.cs  
│   │   ├── HistoryViewModel.cs  
│   │   ├── LoginViewModel.cs  
│   │   ├── MainViewModel.cs  
│   │   ├── PricesViewModel.cs  
│   │   ├── ShowCarsUserViewModel.cs  
│   │   ├── ShowCarsViewModel.cs  
│   │   ├── UserManagementViewModel.cs  
│   │   ├── ViewModelBase.cs  
│   │   └── ViewModelCommand.cs  
│   ├── Views/  
│   │   ├── Add_Car_Window.xaml  
│   │   ├── Add_Customer_Window.xaml  
│   │   ├── Add_User_Window.xaml  
│   │   ├── Admin_Menu.xaml  
│   │   ├── Customer_Management_Control.xaml  
│   │   ├── Edit_Car_Window.xaml  
│   │   ├── Edit_Customer_Window.xaml  
│   │   ├── Edit_Reservation_Window.xaml  
│   │   ├── Edit_User_Window.xaml  
│   │   ├── Fleet_Management_Control.xaml  
│   │   ├── History_Control.xaml  
│   │   ├── Login_Screen.xaml  
│   │   ├── Price_List_Control.xaml  
│   │   ├── Rent_Car_Window.xaml  
│   │   ├── Return_Car_Window.xaml  
│   │   ├── Service_Car_Window.xaml  
│   │   ├── Show_Cars_Control.xaml  
│   │   ├── Show_Cars_User_Control.xaml  
│   │   ├── User_Management_Control.xaml  
│   │   └── User_Menu.xaml  
│   ├── Repositories/  
│   │   ├── CarRepository.cs  
│   │   ├── CustomerRepository.cs  
│   │   ├── DamageRepository.cs  
│   │   ├── DatabaseInitializer.cs  
│   │   ├── IUserRepository.cs  
│   │   ├── RepositoryBase.cs  
│   │   ├── ReservationRepository.cs  
│   │   ├── ServiceRepository.cs  
│   │   └── UserRepository.cs  
│   ├── Styles/  
|   |   ├── ButtonStyles.xaml  
|   |   ├── UIColor.xaml  
│   ├── Converters/  
|   |   ├── AccessToRoleConverter.cs  
|   |   ├── CarDataConverter.cs  
|   |   ├── EmptyToVisibilityConverter.cs  
│   ├── CustomControls/  
|   |   ├── BindablePasswordBox.cs  
│   └── App.xaml  
└── README.md (ten plik)  

## Architektura

* *Model*: klasy biznesowe reprezentujące dane aplikacji.
* *ViewModel*: pośredniczy pomiędzy Modelem a Widokiem; wdraża INotifyPropertyChanged, ICommand.
* *View*: pliki XAML definiujące interfejs użytkownika.

## Diagram klas

![Diagram klas](docs/diagrams/class-diagram.png)

## Instalacja i uruchomienie

1. Sklonuj repozytorium:

   
   git clone https://github.com/Mery-R/Car_Rental_App.git
   
2. Otwórz w Visual Studio używając pliku Car_Rental_App.sln.
3. Upewnij się, że masz zainstalowany SQLite.
4. Plik z bazą daynch utworzy się automatycznie przy uruchomieniu jeśli go nie posiadasz.
5. Uruchom aplikację (F5).

## Użytkowanie

Poniżej znajduje się szczegółowy przewodnik krok po kroku po głównych funkcjonalnościach aplikacji:

1. *Logowanie*

   * Uruchom aplikację.
   * Na ekranie logowania wprowadź swój login i hasło, a następnie kliknij *Zaloguj*.
   * W przypadku błędnych danych zostanie wyświetlony komunikat o nieprawidłowych poświadczeniach.

2. *Nawigacja w aplikacji*

   * Po zalogowaniu dostępne jest boczne menu z opcjami: *Samochody*, *Klienci*, *Wypożyczenia*, *Historia*.
   * Kliknij odpowiednią pozycję, aby przejść do wybranego modułu.

3. *Zarządzanie samochodami*

   * W zakładce *Samochody* zobaczysz listę wszystkich dostępnych pojazdów.
   * *Dodawanie nowego samochodu*:

     1. Kliknij *Dodaj*.
     2. Wypełnij formularz: marka, model, numer VIN, stawka dzienna.
     3. Kliknij *Zapisz*.
   * *Edycja*:

     1. Wybierz wiersz z tabeli.
     2. Kliknij *Edytuj*, zmodyfikuj dane i zatwierdź.
   * *Usuwanie*:

     1. Wybierz samochód.
     2. Kliknij *Usuń*, potwierdź operację.

4. *Zarządzanie klientami*

   * W zakładce *Klienci* przeglądasz listę zarejestrowanych użytkowników.
   * *Dodaj klienta*: wypełnij formularz (imię, nazwisko, PESEL, dane kontaktowe) i kliknij *Zapisz*.
   * *Edycja / usuwanie* działają analogicznie do modułu samochodów.

5. *Tworzenie wypożyczenia*

   * Przejdź do zakładki *Wypożyczenia*.
   * Kliknij *Nowe wypożyczenie*.
   * W formularzu wybierz:

     * Samochód – z listy dostępnych.
     * Klienta – z listy zarejestrowanych.
     * Daty wypożyczenia i zwrotu – wybór z kalendarza.
   * Aplikacja automatycznie obliczy *koszt* (stawka dzienna × liczba dni).
   * Po weryfikacji danych kliknij *Zatwierdź*.

6. *Przegląd historii wypożyczeń*

   * W zakładce *Historia* wyświetlane są wszystkie dokonane transakcje.
   * Możesz filtrować po kliencie, samochodzie, dacie lub statusie (aktywny, zakończony, archiwalny).
   * Kliknij w wiersz, aby zobaczyć szczegóły wypożyczenia.

7. *Obsługa błędów i walidacja*

   * Pola wymagane są oznaczone gwiazdką.
   * Jeśli dane są nieprawidłowe (np. brak daty zwrotu lub puste pole tekstowe), przycisk *Zapisz/Zatwierdź* jest nieaktywny.
   * Aplikacja wyświetla komunikaty błędów w postaci wyskakujących okien (np. „Wybierz samochód przed zatwierdzeniem”).

8. *Wylogowanie*

   * Aby zakończyć sesję, kliknij przycisk *Wyloguj* w lewym dolnym rogu.
   * Aplikacja powróci do ekranu logowania.

## Rozwój i wkład

* Wszelkie zmiany prosimy zgłaszać poprzez Pull Request.
* Zgłaszaj problemy (Issues) z dokładnym opisem kroku po kroku.

## Autorzy

* Mery-R – deweloper
* Pucu03 - deweloper
* agataskalska - deweloper

## Licencja

Projekt udostępniony na licencji MIT. Szczegóły w pliku LICENSE.
