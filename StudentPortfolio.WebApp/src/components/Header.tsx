import type { FC } from "react";
import { SearchInput } from "./SearchInput";
import { AddStudentButton } from "./AddStudentButton";

// interface HeaderProps {}
export const Header: FC = () => {
  return (
    <header className=" bg-lime-800 flex justify-center items-center h-13 relative">
      <AddStudentButton className="absolute left-5 top-6" />
      <SearchInput />
    </header>
  );
};
