import { MantineProvider } from "@mantine/core";
import { Outlet } from "react-router";
import { Header } from "../components/Header";

export default function AppLayout() {
  return (
    <div className={` h-full grid grid-rows-[min-content_minmax(0,1fr)]`}>
      <MantineProvider>
        <Header />
        <main className="overflow-auto">
          <Outlet />
        </main>
      </MantineProvider>
    </div>
  );
}
