package com.wardensky.wordpresshelper;

import java.io.File;
import java.util.List;

import org.apache.log4j.PropertyConfigurator;

import com.jfinal.config.Constants;
import com.jfinal.config.Handlers;
import com.jfinal.config.Interceptors;
import com.jfinal.config.JFinalConfig;
import com.jfinal.config.Plugins;
import com.jfinal.config.Routes;
import com.jfinal.ext.plugin.tablebind.AutoTableBindPlugin;
import com.jfinal.ext.plugin.tablebind.SimpleNameStyles;
import com.jfinal.kit.PropKit;
import com.jfinal.log.Logger;
import com.jfinal.plugin.IPlugin;
import com.jfinal.plugin.c3p0.C3p0Plugin;
import com.jfinal.template.Engine;

public class HhtdJfinalConfig extends JFinalConfig {
	private static final Plugins plugins = new Plugins();
	private static final Constants constants = new Constants();
	protected static final Logger logger = Logger.getLogger(HhtdJfinalConfig.class);

	private String filter = "main";

	public void start() {

		PropertyConfigurator.configure(getLog4jFile());
 		String file = getConfigFile();
 		PropKit.use(file);
		this.configConstant(constants);
		this.configPlugin(plugins);
		startPlugins();
		configConstantFromDb();
	}

	private static void startPlugins() {
		List<IPlugin> pluginList = plugins.getPluginList();
		if (pluginList == null) {
			return;
		}

		for (IPlugin plugin : pluginList) {
			try {
				// process ActiveRecordPlugin devMode
				if (plugin instanceof com.jfinal.plugin.activerecord.ActiveRecordPlugin) {
					com.jfinal.plugin.activerecord.ActiveRecordPlugin arp = (com.jfinal.plugin.activerecord.ActiveRecordPlugin) plugin;
					if (arp.getDevMode() == null) {
						arp.setDevMode(true);
					}
				}

				if (plugin.start() == false) {
					String message = "Plugin start error: " + plugin.getClass().getName();
					logger.error(message);
					throw new RuntimeException(message);
				}
			} catch (Exception e) {
				String message = "Plugin start error: " + plugin.getClass().getName() + ". \n" + e.getMessage();
				logger.error(message, e);
				throw new RuntimeException(message, e);
			}
		}
	}

	private String getConfigFile() {
		ClassLoader ret = getClassLoader();
		String file = ret.getResource(GlobalConfig.CONFIG_FILE).getFile();
		File f = new File(file);
		if (f.exists()) {
			return GlobalConfig.CONFIG_FILE;
		}
		return ".." + File.separator + "config" + File.separator + GlobalConfig.CONFIG_FILE;
	}

	private String getLog4jFile() {
		ClassLoader ret = getClassLoader();
		String file = ret.getResource(GlobalConfig.CONFIG_LOG).getFile();
		File f = new File(file);
		if (f.exists()) {
			return file;
		} else {
			return ".." + File.separator + "config" + File.separator + GlobalConfig.CONFIG_LOG;
		}
	}

	private ClassLoader getClassLoader() {
		ClassLoader ret = Thread.currentThread().getContextClassLoader();
		return ret != null ? ret : getClass().getClassLoader();
	}

	@Override
	public void configConstant(Constants me) {
		me.setDevMode(true);
		if (PropKit.containsKey("mqUrl")) {
			GlobalConfig.MQ_URL = PropKit.get("mqUrl");
		}
	}

	@Deprecated
	@Override
	public void configRoute(Routes me) {
	}

	@Deprecated
	@Override
	public void configEngine(Engine me) {
	}

	@Override
	public void configPlugin(Plugins me) {
		String jdbcUrl = "jdbc:mysql://127.0.0.1:3306/wordpress?zeroDateTimeBehavior=convertToNull&&autoReconnect=true";
		String user = "root";
		String password = "hhtdpwd";
		C3p0Plugin cp = new C3p0Plugin(jdbcUrl, user, password);

		AutoTableBindPlugin atbp = new AutoTableBindPlugin(this.filter, cp, SimpleNameStyles.LOWER_UNDERLINE);
		// atbp.jarFilter("hhtd");
		atbp.setShowSql(true);
		// atbp.addExcludeClasses(BaseModel.class);
		atbp.includeAllJarsInLib(true);
		me.add(cp);
		me.add(atbp);
	}

	@Deprecated
	@Override
	public void configInterceptor(Interceptors me) {
	}

	@Deprecated
	@Override
	public void configHandler(Handlers me) {
	}

	public void configConstantFromDb() {

	}
}
